// Copyright (c) 2022 Matthias Wolf, Mawosoft.

using System;
using Xunit;

namespace BarApp.Tests
{
    public class BarAppTests
    {
        [Fact]
        public void Main_Succeeds()
        {
            Program.Main(Array.Empty<string>());
        }
    }
}
