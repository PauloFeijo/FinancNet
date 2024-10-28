using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinancNetWeb.Services.Api.Base
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger<ServiceBase<T>> _logger;
        protected readonly JsonSerializerOptions _jsonOptions = new()
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            PropertyNameCaseInsensitive = true
        };

        protected T? one;
        protected IEnumerable<T>? list;

        protected string _endpoint = "";
        protected string _entityName = "";

        public ServiceBase(IHttpClientFactory httpClientFactory, ILogger<ServiceBase<T>> logger, string endpoint, string entityName)
        {
            _httpClient = httpClientFactory.CreateClient("FinancNet");
            _logger = logger;
            _endpoint = endpoint;
            _entityName = entityName;
        }

        public async virtual Task<T> Get(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync(_endpoint + id);

                if (response.IsSuccessStatusCode)
                {
                    one = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
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

        public async virtual Task<List<T>> GetAll()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<T>>(_endpoint, _jsonOptions);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao acessar {_entityName}s {_endpoint}.");
                throw new UnauthorizedAccessException();
            }
        }

        public async virtual Task<T> Create(T dto)
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

        public async virtual Task<T> Update(long id, T dto)
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

        public async virtual Task<bool> Delete(long id)
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
