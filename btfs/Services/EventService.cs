using Btfs.Models;

namespace Btfs.Services;

/// <summary>
/// Fonte de dados mock para eventos alinhada com o contrato da API (UUIDs).
/// </summary>
public class EventService
{
    private readonly List<Category> _categories;
    private readonly List<Event> _events;

    public EventService()
    {
        // IDs como strings (UUIDs simulados)
        var catShows = new Category { Id = "c111", Name = "Shows" };
        var catFest = new Category { Id = "c222", Name = "Festivais" };
        var catEsporte = new Category { Id = "c333", Name = "Esportes" };
        var catTeatro = new Category { Id = "c444", Name = "Teatro" };
        var catTech = new Category { Id = "c555", Name = "Tecnologia" };
        var catGastro = new Category { Id = "c666", Name = "Gastronomia" };
        var catArte = new Category { Id = "c777", Name = "Arte" };

        _categories = [catShows, catFest, catEsporte, catTeatro, catTech, catGastro, catArte];

        _events =
        [
            new()
            {
                Id = "e111",
                Title = "Lollapalooza Brasil 2025",
                Description = "O maior festival de música do Brasil retorna ao Autódromo de Interlagos.",
                CoverImageUrl = "https://images.unsplash.com/photo-1470229722913-7c0e2dbbafd3?w=800&q=80",
                StartDate = new DateTime(2025, 3, 28, 12, 0, 0),
                EndDate   = new DateTime(2025, 3, 30, 23, 59, 0),
                CreatedAt = new DateTime(2025, 1, 1),
                IsOnline  = false,
                Status    = "publicado",
                Location  = new Venue { Id = "v111", Name = "Autódromo de Interlagos", City = "São Paulo", State = "SP" },
                Categories = [catFest],
                TicketTypes =
                [
                    new() { Id = "t1", EventId = "e111", Name = "Pista", Price = 490m, QuantityAvailable = 500, SalesStartDate = DateTime.Now.AddDays(-30), SalesEndDate = new DateTime(2025, 3, 27) },
                    new() { Id = "t2", EventId = "e111", Name = "VIP", Price = 980m, QuantityAvailable = 100, SalesStartDate = DateTime.Now.AddDays(-30), SalesEndDate = new DateTime(2025, 3, 27) },
                ]
            },
            new()
            {
                Id = "e222",
                Title = "The Weeknd – After Hours Tour",
                Description = "The Weeknd (também pesquisado como The Weekend) traz sua icônica After Hours Tour para o Brasil.",
                CoverImageUrl = "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?w=800&q=80",
                StartDate = new DateTime(2025, 5, 10, 21, 0, 0),
                EndDate   = new DateTime(2025, 5, 10, 23, 30, 0),
                CreatedAt = new DateTime(2025, 1, 10),
                IsOnline  = false,
                Status    = "publicado",
                Location  = new Venue { Id = "v222", Name = "Allianz Parque", City = "São Paulo", State = "SP" },
                Categories = [catShows],
                TicketTypes =
                [
                    new() { Id = "t3", EventId = "e222", Name = "Pista", Price = 320m, QuantityAvailable = 800, SalesStartDate = DateTime.Now.AddDays(-15), SalesEndDate = new DateTime(2025, 5, 9) },
                    new() { Id = "t4", EventId = "e222", Name = "Cadeira Inferior", Price = 580m, QuantityAvailable = 200, SalesStartDate = DateTime.Now.AddDays(-15), SalesEndDate = new DateTime(2025, 5, 9) },
                ]
            },
            new()
            {
                Id = "e333",
                Title = "TechConf 2025 – IA & Web",
                Description = "A maior conferência de tecnologia do Brasil. Palestras sobre IA, Web3 e Cloud.",
                CoverImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=800&q=80",
                StartDate = new DateTime(2025, 6, 14, 9, 0, 0),
                EndDate   = new DateTime(2025, 6, 15, 18, 0, 0),
                CreatedAt = new DateTime(2025, 2, 5),
                IsOnline  = false,
                Status    = "publicado",
                Location  = new Venue { Id = "v333", Name = "Expo Center Norte", City = "São Paulo", State = "SP" },
                Categories = [catTech],
                TicketTypes =
                [
                    new() { Id = "t5", EventId = "e333", Name = "Estudante", Price = 89m, QuantityAvailable = 300, SalesStartDate = DateTime.Now.AddDays(-60), SalesEndDate = new DateTime(2025, 6, 13) },
                ]
            }
        ];
    }

    public Task<List<Event>> GetEventsAsync(string? categoryFilter = null, string? searchTerm = null)
    {
        var query = _events.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(categoryFilter) && categoryFilter != "Todos")
            query = query.Where(e => e.Categories.Any(c => c.Name == categoryFilter));

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(e => e.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                                  || e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                                  || e.Location?.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true);

        return Task.FromResult(query.ToList());
    }

    public Task<Event?> GetEventByIdAsync(string id) =>
        Task.FromResult(_events.FirstOrDefault(e => e.Id == id));

    public Task<List<Category>> GetCategoriesAsync() =>
        Task.FromResult(_categories);
}
