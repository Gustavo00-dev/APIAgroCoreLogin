using APIAgroCoreLogin.Configuracao;
using APIAgroCoreLogin.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace APIAgroCoreLogin.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<BasicUserRequestModel> _collection;

        public UserRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<BasicUserRequestModel>("apiagrocorelogin.queue.usuarios");
        }

        public async Task CreateAsync(BasicUserRequestModel user, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(user, cancellationToken: cancellationToken);
        }
    }
}
