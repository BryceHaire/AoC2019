using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<string> inputs = File
                                    .ReadAllLines("C:\\Users\\bryce.haire\\AoC\\Day3\\input.txt")
                                    .ToList();   
            Line Line1 = new Line() { Input = inputs[0] };
            Line Line2 = new Line() { Input = inputs[1] };

            Line1.GenerateMovement();
            Line2.GenerateMovement();
            
            var intersections = Line1.Locations.Intersect(Line2.Locations, new TileLocationComparer());

            var currentDistance = int.MaxValue;
            foreach(var intersect in intersections)
            {
                var distance = Math.Abs(intersect.X) + Math.Abs(intersect.Y);
                if(distance < currentDistance)
                {
                    currentDistance = distance;
                }
            }

            Console.WriteLine($"Part 1 Answer: {currentDistance}");

            var firstIntersection = intersections.First();
            int count = 0;
            foreach(var location in Line1.Locations)
            {
                count++;
                if(location.X == firstIntersection.X 
                    && location.Y == firstIntersection.Y)
                {
                    break;
                }
            }

            foreach(var location in Line2.Locations)
            {
                count++;
                if(location.X == firstIntersection.X 
                    && location.Y == firstIntersection.Y)
                {
                    break;
                }
            }

            Console.WriteLine($"Part 2 Answer: {count}");

        }
        private class Line 
        {
            public string Input {get;set;}

            public List<TileLocation> Locations {get; private set;}

            public List<Movement> Movements {get; private set;}

            public TileLocation CurrentLocation {get;set;} = new TileLocation(){ X = 0, Y= 0};
            public void GenerateMovement()
            {
                Locations = new List<TileLocation>();
                Movements = new List<Movement>();
                foreach(var input in Input.Split(','))
                {
                    var direction = ParseDirection(input.ToCharArray()[0]);
                    var length = int.Parse(input.Substring(1));
                    var movement = new Movement()
                    {
                        Direction = direction,
                        Length = length
                    };

                    CurrentLocation = ProcessMovement(movement);
                }

            }

            private TileLocation ProcessMovement(Movement movement)
            {
                var response = new TileLocation();
                switch(movement.Direction){
                    case Direction.Right:
                        for(int i = 1; i < movement.Length; i++)
                        {
                            Locations.Add(new TileLocation(){
                                X = CurrentLocation.X + i,
                                Y = CurrentLocation.Y
                            });
                        }
                        response = new TileLocation()
                        {
                            X = CurrentLocation.X + movement.Length,
                            Y = CurrentLocation.Y
                        };
                        break;
                    case Direction.Left:
                        for(int i = 1; i < movement.Length; i++)
                        {
                            Locations.Add(new TileLocation(){
                                X = CurrentLocation.X - i,
                                Y = CurrentLocation.Y
                            });
                        }
                        response = new TileLocation()
                        {
                            X = CurrentLocation.X - movement.Length,
                            Y = CurrentLocation.Y
                        };
                        break;
                    case Direction.Up:
                        for(int i = 1; i < movement.Length; i++)
                        {
                            Locations.Add(new TileLocation(){
                                X = CurrentLocation.X ,
                                Y = CurrentLocation.Y + i
                            });
                        }
                        response = new TileLocation()
                        {
                            X = CurrentLocation.X,
                            Y = CurrentLocation.Y + movement.Length
                        };
                        break;
                    case Direction.Down:
                        for(int i = 1; i < movement.Length; i++)
                        {
                            Locations.Add(new TileLocation(){
                                X = CurrentLocation.X,
                                Y = CurrentLocation.Y - i
                            });
                        }
                        response = new TileLocation()
                        {
                            X = CurrentLocation.X,
                            Y = CurrentLocation.Y - movement.Length
                        };
                        break;
                    default: {
                        throw new Exception("Not Supported");
                    }
                }

                Movements.Add(movement);
                Locations.Add(response);
                return response;
            }

            private Direction ParseDirection(char c)
            {
                switch(c){
                    case 'U':
                        return Direction.Up;
                    case 'D':
                        return Direction.Down;
                    case 'L':
                        return Direction.Left;
                    case 'R':
                        return Direction.Right;
                    default:
                        throw new Exception("Not Supported");
                }
            }
        }

        private class Movement {
            public Direction Direction {get;set;}
            public int Length {get;set;} 
        }

        private enum Direction {
            Up,
            Down,
            Left, 
            Right
        }

        private class TileLocation {
            public int X {get;set;}
            public int Y {get;set;}
        }

class TileLocationComparer : IEqualityComparer<TileLocation>
{
    // Products are equal if their names and product numbers are equal.
    public bool Equals(TileLocation x, TileLocation y)
    {
       
        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the products' properties are equal.
        return x.X == y.X && x.Y == y.Y;
    }

    // If Equals() returns true for a pair of objects 
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(TileLocation product)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(product, null)) return 0;

        //Calculate the hash code for the product.
        return product.X.GetHashCode() ^ product.Y.GetHashCode();
    }

}
    }
}
