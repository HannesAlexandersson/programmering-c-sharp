
﻿using Assignment5;

// create two boxes
var box1 = new Box()
{
    X = 3,
    Y = 2,
    Width = 7,
    Height = 4
};

var box2 = new Box()
{
    X = 17,
    Y = 4,
    Width = 13,
    Height = 8
};

// then draw both on the screen
box1.Draw();
box2.Draw();

Console.ReadLine();
