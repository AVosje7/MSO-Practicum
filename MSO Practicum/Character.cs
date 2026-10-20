using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace MSOPracticum
{
    public class Character
    {
        public Direction direction { get; private set; }
        public Point position { get; private set; }

        public Character(Direction direction, Point position)
        {
            this.direction = direction;
            this.position = position;
        }

        public void Move(int amount)
        {
            switch (direction)
            {
                case Direction.East:
                    position = new Point(position.X + amount, position.Y);
                    break;
                case Direction.South:
                    position = new Point(position.X, position.Y + amount);
                    break;
                case Direction.West:
                    position = new Point(position.X - amount, position.Y);
                    break;
                case Direction.North:
                    position = new Point(position.X, position.Y - amount);
                    break;
            }
        }

        public void Turn(bool clockwise)
        {
            if (clockwise)
            {
                direction = (Direction)(((int)direction + 1) % 4);
            }
            else
            {
                direction = (Direction)(((int)direction + 3) % 4);
            }
        }

        public override string ToString()
        {
            return $"({position.X},{position.Y}) facing {direction}";
        }
    }

#if DEBUG
#region Tests
public class CharacterTests
{
    private static Character At(Direction dir, int x = 0, int y = 0) =>
        new Character(dir, new Point(x, y));

    [Theory]
    [InlineData(Direction.East, 3, 0)]
    [InlineData(Direction.South, 0, 3)]
    [InlineData(Direction.West, -3, 0)]
    [InlineData(Direction.North, 0, -3)]
    public void Move_GoesInTheFacingDirection(Direction dir, int expectedX, int expectedY)
    {
        var c = At(dir);
        c.Move(3);
        Assert.Equal(new Point(expectedX, expectedY), c.position);
    }

    [Fact]
    public void Move_Zero_DoesNotChangePosition()
    {
        var c = At(Direction.East, 2, 2);
        c.Move(0);
        Assert.Equal(new Point(2, 2), c.position);
    }

    [Fact]
    public void Move_Twice_Accumulates()
    {
        var c = At(Direction.East);
        c.Move(2);
        c.Move(3);
        Assert.Equal(new Point(5, 0), c.position);
    }

    [Fact]
    public void Move_DoesNotChangeDirection()
    {
        var c = At(Direction.South);
        c.Move(5);
        Assert.Equal(Direction.South, c.direction);
    }


    [Theory]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.West, Direction.North)]
    [InlineData(Direction.North, Direction.East)]
    public void Turn_Clockwise_RotatesRight(Direction start, Direction expected)
    {
        var c = At(start);
        c.Turn(true);
        Assert.Equal(expected, c.direction);
    }

    [Theory]
    [InlineData(Direction.East, Direction.North)]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.West, Direction.South)]
    [InlineData(Direction.South, Direction.East)]
    public void Turn_CounterClockwise_RotatesLeft(Direction start, Direction expected)
    {
        var c = At(start);
        c.Turn(false);
        Assert.Equal(expected, c.direction);
    }


    [Fact]
    public void Turn_DoesNotChangePosition()
    {
        var c = At(Direction.East, 3, 3);
        c.Turn(true);
        Assert.Equal(new Point(3, 3), c.position);
    }

    [Fact]
    public void ToString_ShowsPositionAndDirection()
    {
        var c = At(Direction.East, 2, 1);
        Assert.Equal("(2,1) facing East", c.ToString());
    }

    [Fact]
    public void Example_EndsAtTwoOne()
    {
    var c = At(Direction.East);
    c.Move(1);
    c.Turn(true);   
    c.Move(1);
    c.Turn(false);  
    c.Move(1);
    Assert.Equal(new Point(2, 1), c.position);
}
}
#endregion
#endif
}
