using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Enemies;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Runner;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Bases;
using Itmo.ObjectOrientedProgramming.Lab1.SysUtil;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class SpaceShipsFlyingTests
{
    // 1 - Маршрут средней длины в туманности повышенной плотности пространства.
    // Обработать два корабля (`[Theory]`): Прогулочный челнок и Авгур.
    // Первый не имеет прыжковых двигателей, второй имеет недостаточную дальность.
    // Оба не должны завершить маршрут.
    [Theory]
    [InlineData("Walker")]
    [InlineData("Avgur")]
    public static void AvgurWalkerShipLostTest(string shipType)
    {
        SpaceShip ship = shipType == "Walker"
            ? new Walker()
            : new Avgur(100);
        ISpaceEnv env = new NebuleSpaceEnv(1000);

        Assert.Equal(Result.ShipLost, env.Accept(ship).Result);
    }

    // 2 - Вспышка антиматерии в подпространственном канале. Обработать два корабля ([Theory]):
    // Ваклас и Ваклас с фотонными дефлекторами. В первом случае маршрут не должен быть пройден из-за
    // потери экипажа, во втором – пройден.
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void Test2(bool photoDeflector)
    {
        SpaceShip ship = photoDeflector
            ? new Walker(1000, true)
            : new Walker();

        ISpaceEnv env = new SimpleSpaceEnv(800, new Collection<IEnemy>
            {
                new AmFlare(2),
            });

        Result result = photoDeflector
            ? Result.Success
            : Result.CrewDead;

        Assert.Equal(result, env.Accept(ship).Result);
    }

    // 3 - Космо-кит в туманности нитринных частиц. Обработать три корабля ([Theory]):
    // Ваклас, Авгур и Мередиан. Первый – уничтожен после столкновения, второй – только потерял щиты,
    // третий – был не тронут.
    [Theory]
    [InlineData("Vaclas")]
    [InlineData("Avgur")]
    [InlineData("Meredian")]
    public static void ShipsAndWhalesCollisionTest(string shipType)
    {
        SpaceShip ship = shipType switch
        {
            "Vaclas" => new Vaclas(),
            "Avgur" => new Avgur(),
            "Meredian" => new Meredian(),
            _ => new Stella(),      // unpossible
        };

        ISpaceEnv env = new NitrinSpaceEnv(800, new Collection<IEnemy>
        {
            new CosmoWhale(1000, 1),
        });

        Result expected = shipType switch
        {
            "Vaclas" => Result.ShipLost,
            "Avgur" => Result.Success,
            "Meredian" => Result.Success,
            _ => Result.CrewDead,   // unpossible
        };

        Assert.Equal(expected, env.Accept(ship).Result);
    }

    [Theory]
    [InlineData("Vaclas")]
    [InlineData("Avgur")]
    [InlineData("Meredian")]
    public static void ShipsAndWhalesCollisionWithShipSelectorTest(string shipType)
    {
        SpaceShip ship = shipType switch
        {
            "Vaclas" => new Vaclas(),
            "Avgur" => new Avgur(),
            "Meredian" => new Meredian(),
            _ => new Stella(),      // unpossible
        };

        ISpaceEnv env1 = new NitrinSpaceEnv(800, new Collection<IEnemy>()
        {
            new CosmoWhale(1000, 1),
        });

        var way = new Collection<ISpaceEnv> { env1, };
        var mWay = new MilkyWay(way);

        Result expected = shipType switch
        {
            "Vaclas" => Result.ShipLost,
            "Avgur" => Result.Success,
            "Meredian" => Result.Success,
            _ => Result.CrewDead,   // impossible
        };
        var shipRunner = new ShipRunner();

        Assert.Equal(expected, shipRunner.Run(mWay, ship).Result);
    }

    // 4 - Короткий маршрут в обычном космосе. Запускаем Прогулочный челнок и Ваклас.
    // Т.к. у Вакласа большая стоимость полёта, то Прогулочный челнок должен быть
    // оптимальнее для данного маршрута.
    [Fact]
    public static void VaclasWalkerShortDistanceTest()
    {
        IList<SpaceShip> ships = new List<SpaceShip>
        {
            new Vaclas(),
            new Walker(),
        };
        var way = new MilkyWay(new Collection<ISpaceEnv>
        {
            new SimpleSpaceEnv(700),
        });
        var selector = new ShipSelector();

        Assert.Equal(ResultingShip.Walker, selector.Select(way, ships));
    }

    // 5 - Маршрут средней длины в туманности повышенной плотности пространства.
    // Запускаем Авгур и Стеллу. Т.к. у Авгура возможная дальность прохождения
    // по подпространственным каналам меньше – должна быть выбрана Стелла.
    [Fact]
    public static void AvgurStellaMiddleDistanceTest()
    {
        IList<SpaceShip> ships = new List<SpaceShip>
        {
            new Avgur(2000),
            new Stella(2000),
        };
        var way = new MilkyWay(new Collection<ISpaceEnv>
        {
            new NebuleSpaceEnv(2000),
        });
        var selector = new ShipSelector();

        Assert.Equal(ResultingShip.Stella, selector.Select(way, ships));
    }

    // 6 - Маршрут в туманости нитринных частиц. Запускаем Прогулочный челнок и Ваклас.
    // Должен быть выбран Ваклас.
    [Fact]
    public static void NitroSpaceWalkerVaclasTest()
    {
        IList<SpaceShip> ships = new List<SpaceShip>
        {
            new Walker(),
            new Vaclas(),
        };
        var way = new MilkyWay(new Collection<ISpaceEnv>
        {
            new NitrinSpaceEnv(4000),
        });
        var selector = new ShipSelector();

        Assert.Equal(ResultingShip.Vaclas, selector.Select(way, ships));
    }

    // my tests
    [Fact]
    public static void WayOfDifferentEnvsTest()
    {
        var way = new MilkyWay(new Collection<ISpaceEnv>
        {
            new SimpleSpaceEnv(700, new Collection<IEnemy>
            {
                new Asteroid(30, 7),
            }),
            new NitrinSpaceEnv(1000),
        });
        var selector = new ShipSelector();

        Assert.Equal(ResultingShip.Avgur, selector.Select(way, GetAllShips()));
    }

    [Fact]
    public static void WayOfDiffEnvsAndEnemiesTest()
    {
        var way = new MilkyWay(new Collection<ISpaceEnv>
        {
            new SimpleSpaceEnv(700, new Collection<IEnemy>
            {
                new Asteroid(30, 7),
            }),
            new NitrinSpaceEnv(1000),
            new NebuleSpaceEnv(100, new Collection<IEnemy>
            {
                new AmFlare(1),
            }),
        });
        var selector = new ShipSelector();

        Assert.Equal(ResultingShip.NoOptimal, selector.Select(way, GetAllShips()));
    }

    [Fact]
    public static void PhotoDeflectorsTest()
    {
        var way = new MilkyWay(new Collection<ISpaceEnv>
        {
            new SimpleSpaceEnv(700, new Collection<IEnemy>
            {
                new Asteroid(30, 2),
            }),
            new NitrinSpaceEnv(500, new Collection<IEnemy>
            {
                new CosmoWhale(1000, 1),
            }),
            new NebuleSpaceEnv(100, new Collection<IEnemy>
            {
                new AmFlare(2),
            }),
        });
        var selector = new ShipSelector();

        Assert.Equal(ResultingShip.Avgur, selector.Select(way, GetAllShips(true)));
    }

    private static IList<SpaceShip> GetAllShips(bool photo = false)
    {
        return new List<SpaceShip>
        {
            new Avgur(1e9, photo),
            new Meredian(1e9, photo),
            new Stella(1e9, photo),
            new Vaclas(1e9, photo),
            new Walker(1e9, photo),
        };
    }
}
