using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Tests;

public class QueriesTestFixture
{
    public readonly List<Client> Clients;
    public readonly List<Restaurant> Restaurants;
    public readonly List<DishCategory> Categories;
    public readonly List<Dish> Dishes;
    public readonly List<Order> Orders;

    public QueriesTestFixture()
    {
        Clients = GetClients();
        Restaurants = GetRestaurants();
        Categories = GetCategories();
        Dishes = GetDishes();
        Orders = GetOrders();
    }

    public static List<Client> GetClients()
    {
        return
        [
            new()
            {
                Id = 1,
                FullName = "Зубенко Михаил Петрович",
                Phone = "+79277777777",
                DeliveryAddress = "г. Самара, ул. Ленина, д. 10"
            },
            new()
            {
                Id = 2,
                FullName = "Дылда Ольга Олеговна",
                Phone = "+79270001111",
                DeliveryAddress = "г. Самара, ул. Гагарина, д. 15"
            },
            new()
            {
                Id = 3,
                FullName = "Заболотный Антон Иванович",
                Phone = "+79273333333",
                DeliveryAddress = "г. Самара, ул. Гаражная, д. 21"
            },
            new()
            {
                Id = 4,
                FullName = "Скорлупа Иннокентий Сергеевич",
                Phone = "+79270101010",
                DeliveryAddress = "г. Самара, ул. Гая, д. 8"
            },
            new()
            {
                Id = 5,
                FullName = "Иванов Иван Иванович",
                Phone = "+79270202020",
                DeliveryAddress = "г. Самара, ул. Революционная, д. 32"
            },
            new()
            {
                Id = 6,
                FullName = "Петушков Илья Викторович",
                Phone = "+7270000001",
                DeliveryAddress = "г. Самара, ул. Ново-Садовая, д. 14"
            },
            new()
            {
                Id = 7,
                FullName = "Костыль Ирина Петровна",
                Phone = "+79371004554",
                DeliveryAddress = "г. Самара, ул. Стара-Загора, д. 5"
            },
            new()
            {
                Id = 8,
                FullName = "Петров Петр Петрович",
                Phone = "+7271232323",
                DeliveryAddress = "г. Самара, ул. Дыбенко, д. 19"
            },
            new()
            {
                Id = 9,
                FullName = "Плотников Иван Иванович",
                Phone = "+79276547656",
                DeliveryAddress = "г. Самара, ул. Гаражная, д. 27"
            },
            new()
            {
                Id = 10,
                FullName = "Колодин Алексей Сергеевич",
                Phone = "+7271044141",
                DeliveryAddress = "г. Самара, ул. Мяги, д. 11"
            }
        ];
    }

    public static List<Restaurant> GetRestaurants()
    {
        return
        [
            new()
            {
                Id = 1,
                Name = "Ростикс",
                Address = "г. Самара, ул. Аэродромная, д. 25",
                Rating = 4.8,
                OpenTime = new TimeOnly(9, 0),
                CloseTime = new TimeOnly(23, 0)
            },
            new()
            {
                Id = 2,
                Name = "Вкусно и точка",
                Address = "г. Самара, ул. Дыбенко, д. 30",
                Rating = 4.5,
                OpenTime = new TimeOnly(8, 0),
                CloseTime = new TimeOnly(23, 0)
            },
            new()
            {
                Id = 3,
                Name = "Фуджи",
                Address = "г. Самара, ул. Гагарина, д. 42",
                Rating = 4.6,
                OpenTime = new TimeOnly(10, 0),
                CloseTime = new TimeOnly(23, 0)
            },
            new()
            {
                Id = 4,
                Name = "Тануки",
                Address = "г. Самара, ул. Стара-Загора, д. 35",
                Rating = 4.8,
                OpenTime = new TimeOnly(11, 0),
                CloseTime = new TimeOnly(23, 0)
            },
            new()
            {
                Id = 5,
                Name = "Комитет",
                Address = "г. Самара, ул. Дыбенко, д. 12",
                Rating = 4.9,
                OpenTime = new TimeOnly(10, 0),
                CloseTime = new TimeOnly(23, 15)
            },
            new()
            {
                Id = 6,
                Name = "Шашлычная",
                Address = "г. Самара, ул. Революционная, д. 51",
                Rating = 4.3,
                OpenTime = new TimeOnly(9, 0),
                CloseTime = new TimeOnly(22, 30)
            },
            new()
            {
                Id = 7,
                Name = "Перчини",
                Address = "г. Самара, ул. Ново-Садовая, д. 76",
                Rating = 4.6,
                OpenTime = new TimeOnly(8, 30),
                CloseTime = new TimeOnly(22, 0)
            },
            new()
            {
                Id = 8,
                Name = "Дом Нино",
                Address = "г. Самара, ул. Пушкина, д. 14",
                Rating = 4.9,
                OpenTime = new TimeOnly(11, 0),
                CloseTime = new TimeOnly(23, 0)
            },
            new()
            {
                Id = 9,
                Name = "Супра",
                Address = "г. Самара, ул. Мяги, д. 28",
                Rating = 4.9,
                OpenTime = new TimeOnly(10, 0),
                CloseTime = new TimeOnly(23, 0)
            },
            new()
            {
                Id = 10,
                Name = "Кафе Чаша",
                Address = "г. Самара, ул. Куйбышева, д. 10",
                Rating = 4.5,
                OpenTime = new TimeOnly(8, 0),
                CloseTime = new TimeOnly(18, 0)
            }
        ];
    }

    public static List<DishCategory> GetCategories()
    {
        return
        [
            new() { Id = 1, Name = "Пицца" },
            new() { Id = 2, Name = "Суши" },
            new() { Id = 3, Name = "Бургеры" },
            new() { Id = 4, Name = "Салаты" },
            new() { Id = 5, Name = "Супы" },
            new() { Id = 6, Name = "Горячие блюда" },
            new() { Id = 7, Name = "Десерты" },
            new() { Id = 8, Name = "Напитки" },
            new() { Id = 9, Name = "Закуски" },
            new() { Id = 10, Name = "Соусы" }
        ];
    }

    public List<Dish> GetDishes()
    {
        return
        [
            new()
            {
                Id = 1,
                Name = "Пицца Маргарита",
                Weight = 450,
                Price = 550m,
                CategoryId = 1,
                Category = Categories.Single(x => x.Id == 1),
                RestaurantId = 1,
                Restaurant = Restaurants.Single(x => x.Id == 1)
            },
            new()
            {
                Id = 2,
                Name = "Чикенбургер",
                Weight = 300,
                Price = 420m,
                CategoryId = 3,
                Category = Categories.Single(x => x.Id == 3),
                RestaurantId = 1,
                Restaurant = Restaurants.Single(x => x.Id == 1)
            },
            new()
            {
                Id = 3,
                Name = "Бургер классический",
                Weight = 320,
                Price = 390m,
                CategoryId = 3,
                Category = Categories.Single(x => x.Id == 3),
                RestaurantId = 2,
                Restaurant = Restaurants.Single(x => x.Id == 2)
            },
            new()
            {
                Id = 4,
                Name = "Картофель фри",
                Weight = 180,
                Price = 190m,
                CategoryId = 9,
                Category = Categories.Single(x => x.Id == 9),
                RestaurantId = 2,
                Restaurant = Restaurants.Single(x => x.Id == 2)
            },
            new()
            {
                Id = 5,
                Name = "Филадельфия",
                Weight = 280,
                Price = 650m,
                CategoryId = 2,
                Category = Categories.Single(x => x.Id == 2),
                RestaurantId = 3,
                Restaurant = Restaurants.Single(x => x.Id == 3)
            },
            new()
            {
                Id = 6,
                Name = "Калифорния",
                Weight = 260,
                Price = 590m,
                CategoryId = 2,
                Category = Categories.Single(x => x.Id == 2),
                RestaurantId = 3,
                Restaurant = Restaurants.Single(x => x.Id == 3)
            },
            new()
            {
                Id = 7,
                Name = "Том Ям",
                Weight = 400,
                Price = 720m,
                CategoryId = 5,
                Category = Categories.Single(x => x.Id == 5),
                RestaurantId = 4,
                Restaurant = Restaurants.Single(x => x.Id == 4)
            },
            new()
            {
                Id = 8,
                Name = "Лапша с курицей",
                Weight = 350,
                Price = 540m,
                CategoryId = 6,
                Category = Categories.Single(x => x.Id == 6),
                RestaurantId = 4,
                Restaurant = Restaurants.Single(x => x.Id == 4)
            },
            new()
            {
                Id = 9,
                Name = "Стейк из говядины",
                Weight = 350,
                Price = 1250m,
                CategoryId = 6,
                Category = Categories.Single(x => x.Id == 6),
                RestaurantId = 5,
                Restaurant = Restaurants.Single(x => x.Id == 5)
            },
            new()
            {
                Id = 10,
                Name = "Салат Цезарь",
                Weight = 250,
                Price = 490m,
                CategoryId = 4,
                Category = Categories.Single(x => x.Id == 4),
                RestaurantId = 5,
                Restaurant = Restaurants.Single(x => x.Id == 5)
            },
            new()
            {
                Id = 11,
                Name = "Шашлык из свинины",
                Weight = 400,
                Price = 850m,
                CategoryId = 6,
                Category = Categories.Single(x => x.Id == 6),
                RestaurantId = 6,
                Restaurant = Restaurants.Single(x => x.Id == 6)
            },
            new()
            {
                Id = 12,
                Name = "Паста Карбонара",
                Weight = 350,
                Price = 620m,
                CategoryId = 6,
                Category = Categories.Single(x => x.Id == 6),
                RestaurantId = 7,
                Restaurant = Restaurants.Single(x => x.Id == 7)
            },
            new()
            {
                Id = 13,
                Name = "Тирамису",
                Weight = 180,
                Price = 390m,
                CategoryId = 7,
                Category = Categories.Single(x => x.Id == 7),
                RestaurantId = 8,
                Restaurant = Restaurants.Single(x => x.Id == 8)
            },
            new()
            {
                Id = 14,
                Name = "Хачапури",
                Weight = 400,
                Price = 580m,
                CategoryId = 6,
                Category = Categories.Single(x => x.Id == 6),
                RestaurantId = 9,
                Restaurant = Restaurants.Single(x => x.Id == 9)
            },
            new()
            {
                Id = 15,
                Name = "Борщ",
                Weight = 350,
                Price = 360m,
                CategoryId = 5,
                Category = Categories.Single(x => x.Id == 5),
                RestaurantId = 10,
                Restaurant = Restaurants.Single(x => x.Id == 10)
            }
        ];
    }

    public List<Order> GetOrders()
    {
        return
        [
            new()
            {
                Id = 1,
                ClientId = 1,
                Client = Clients.Single(x => x.Id == 1),
                RestaurantId = 1,
                Restaurant = Restaurants.Single(x => x.Id == 1),
                OrderTime = new DateTime(2026, 9, 1, 12, 10, 0),
                DeliveryTime = new DateTime(2026, 9, 1, 12, 45, 0),
                TotalPrice = 970m,
                Dishes = [Dishes[0], Dishes[1]]
            },
            new()
            {
                Id = 2,
                ClientId = 2,
                Client = Clients.Single(x => x.Id == 2),
                RestaurantId = 2,
                Restaurant = Restaurants.Single(x => x.Id == 2),
                OrderTime = new DateTime(2026, 9, 1, 13, 20, 0),
                DeliveryTime = new DateTime(2026, 9, 1, 13, 55, 0),
                TotalPrice = 580m,
                Dishes = [Dishes[2], Dishes[3]]
            },
            new()
            {
                Id = 3,
                ClientId = 3,
                Client = Clients.Single(x => x.Id == 3),
                RestaurantId = 3,
                Restaurant = Restaurants.Single(x => x.Id == 3),
                OrderTime = new DateTime(2026, 9, 1, 14, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 1, 14, 40, 0),
                TotalPrice = 650m,
                Dishes = [Dishes[4]]
            },
            new()
            {
                Id = 4,
                ClientId = 4,
                Client = Clients.Single(x => x.Id == 4),
                RestaurantId = 4,
                Restaurant = Restaurants.Single(x => x.Id == 4),
                OrderTime = new DateTime(2026, 9, 1, 15, 15, 0),
                DeliveryTime = new DateTime(2026, 9, 1, 15, 50, 0),
                TotalPrice = 1260m,
                Dishes = [Dishes[6], Dishes[7]]
            },
            new()
            {
                Id = 5,
                ClientId = 5,
                Client = Clients.Single(x => x.Id == 5),
                RestaurantId = 5,
                Restaurant = Restaurants.Single(x => x.Id == 5),
                OrderTime = new DateTime(2026, 9, 2, 12, 30, 0),
                DeliveryTime = new DateTime(2026, 9, 2, 13, 20, 0),
                TotalPrice = 1740m,
                Dishes = [Dishes[8], Dishes[9]]
            },
            new()
            {
                Id = 6,
                ClientId = 6,
                Client = Clients.Single(x => x.Id == 6),
                RestaurantId = 6,
                Restaurant = Restaurants.Single(x => x.Id == 6),
                OrderTime = new DateTime(2026, 9, 2, 13, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 2, 13, 45, 0),
                TotalPrice = 850m,
                Dishes = [Dishes[10]]
            },
            new()
            {
                Id = 7,
                ClientId = 7,
                Client = Clients.Single(x => x.Id == 7),
                RestaurantId = 7,
                Restaurant = Restaurants.Single(x => x.Id == 7),
                OrderTime = new DateTime(2026, 9, 2, 14, 10, 0),
                DeliveryTime = new DateTime(2026, 9, 2, 14, 50, 0),
                TotalPrice = 620m,
                Dishes = [Dishes[11]]
            },
            new()
            {
                Id = 8,
                ClientId = 8,
                Client = Clients.Single(x => x.Id == 8),
                RestaurantId = 8,
                Restaurant = Restaurants.Single(x => x.Id == 8),
                OrderTime = new DateTime(2026, 9, 2, 15, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 2, 15, 35, 0),
                TotalPrice = 390m,
                Dishes = [Dishes[12]]
            },
            new()
            {
                Id = 9,
                ClientId = 9,
                Client = Clients.Single(x => x.Id == 9),
                RestaurantId = 9,
                Restaurant = Restaurants.Single(x => x.Id == 9),
                OrderTime = new DateTime(2026, 9, 3, 11, 30, 0),
                DeliveryTime = new DateTime(2026, 9, 3, 12, 10, 0),
                TotalPrice = 580m,
                Dishes = [Dishes[13]]
            },
            new()
            {
                Id = 10,
                ClientId = 10,
                Client = Clients.Single(x => x.Id == 10),
                RestaurantId = 10,
                Restaurant = Restaurants.Single(x => x.Id == 10),
                OrderTime = new DateTime(2026, 9, 3, 12, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 3, 12, 30, 0),
                TotalPrice = 360m,
                Dishes = [Dishes[14]]
            },
            new()
            {
                Id = 11,
                ClientId = 1,
                Client = Clients.Single(x => x.Id == 1),
                RestaurantId = 1,
                Restaurant = Restaurants.Single(x => x.Id == 1),
                OrderTime = new DateTime(2026, 9, 3, 13, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 3, 13, 25, 0),
                TotalPrice = 550m,
                Dishes = [Dishes[0]]
            },
            new()
            {
                Id = 12,
                ClientId = 2,
                Client = Clients.Single(x => x.Id == 2),
                RestaurantId = 2,
                Restaurant = Restaurants.Single(x => x.Id == 2),
                OrderTime = new DateTime(2026, 9, 3, 14, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 3, 14, 30, 0),
                TotalPrice = 390m,
                Dishes = [Dishes[2]]
            },
            new()
            {
                Id = 13,
                ClientId = 3,
                Client = Clients.Single(x => x.Id == 3),
                RestaurantId = 3,
                Restaurant = Restaurants.Single(x => x.Id == 3),
                OrderTime = new DateTime(2026, 9, 4, 12, 15, 0),
                DeliveryTime = new DateTime(2026, 9, 4, 12, 50, 0),
                TotalPrice = 1240m,
                Dishes = [Dishes[4], Dishes[5]]
            },
            new()
            {
                Id = 14,
                ClientId = 4,
                Client = Clients.Single(x => x.Id == 4),
                RestaurantId = 4,
                Restaurant = Restaurants.Single(x => x.Id == 4),
                OrderTime = new DateTime(2026, 9, 4, 13, 30, 0),
                DeliveryTime = new DateTime(2026, 9, 4, 14, 20, 0),
                TotalPrice = 720m,
                Dishes = [Dishes[6]]
            },
            new()
            {
                Id = 15,
                ClientId = 5,
                Client = Clients.Single(x => x.Id == 5),
                RestaurantId = 5,
                Restaurant = Restaurants.Single(x => x.Id == 5),
                OrderTime = new DateTime(2026, 9, 4, 15, 0, 0),
                DeliveryTime = new DateTime(2026, 9, 4, 15, 45, 0),
                TotalPrice = 1250m,
                Dishes = [Dishes[8]]
            },
            new()
            {
                Id = 16,
                ClientId = 6,
                Client = Clients.Single(x => x.Id == 6),
                RestaurantId = 1,
                Restaurant = Restaurants.Single(x => x.Id == 1),
                OrderTime = new DateTime(2026, 9, 5, 12, 30, 0),
                DeliveryTime = new DateTime(2026, 9, 5, 13, 5, 0),
                TotalPrice = 970m,
                Dishes = [Dishes[0], Dishes[1]]
            },
            new()
            {
                Id = 17,
                ClientId = 7,
                Client = Clients.Single(x => x.Id == 7),
                RestaurantId = 2,
                Restaurant = Restaurants.Single(x => x.Id == 2),
                OrderTime = new DateTime(2026, 9, 5, 13, 15, 0),
                DeliveryTime = new DateTime(2026, 9, 5, 13, 50, 0),
                TotalPrice = 580m,
                Dishes = [Dishes[2], Dishes[3]]
            }
        ];
    }
}