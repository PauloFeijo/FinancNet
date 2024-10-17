using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace FinancNetWeb.Services.Api.Base
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly HttpClient _httpClient;
        public ILogger<ServiceBase<T>> _logger;
        private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        private T? one;
        private IEnumerable<T>? list;

        private string _endpoint = "";
        private string _entityName = "";

        public ServiceBase(IHttpClientFactory httpClientFactory, ILogger<ServiceBase<T>> logger, string endpoint, string entityName)
        {
            _httpClient = httpClientFactory.CreateClient("FinancNet");
            _logger = logger;
            _endpoint = endpoint;
            _entityName = entityName;
        }

        public async Task<T> Get(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync(_endpoint + id);

                if (response.IsSuccessStatusCode)
                {
                    one = await response.Content.ReadFromJsonAsync<T>();
                    return one;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter {_entityName} {id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter {_entityName} {id}.");
                throw new UnauthorizedAccessException();
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<T>>(_endpoint);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao acessar {_entityName}s {_endpoint}.");
                throw new UnauthorizedAccessException();
            }
        }

        public async Task<T> Create(T dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                one = await JsonSerializer.DeserializeAsync<T>(apiResponse, _jsonOptions);
                return one;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return null;
        }

        public async Task<T> Update(long id, T dto)
        {
            var response = await _httpClient.PutAsJsonAsync(_endpoint + id, dto);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                one = await JsonSerializer.DeserializeAsync<T>(apiResponse, _jsonOptions);
                return one;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return null;
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _httpClient.DeleteAsync(_endpoint + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return false;
        }
    }
}
