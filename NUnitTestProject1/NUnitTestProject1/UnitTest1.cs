using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    [TestTexture]
    public class Tests
    {
        //zmienna grid uzywana do testow
        GridSpace grid;

        //metoda oznaczona [setup] jest wykonywana zawsze jako pierwsza przez jakimkolwiek testem
        [SetUp]
        public void Setup()
        {
            //metoda przypisuje zmiennej grid wartosc new GridSpace(); aby uniknac NULL'a w testach (testy moga wtedy byc nie poprawne)
            grid = new GridSpace();
        }

        //pierwszy test jednostkowy. Oznaczenie [Test] informuje kompilator ze metoda jest testem
        [Test]
        //Nazwa metody mowi o metodzie jaka testuje
        public void ResetSpaceTest()
        {
            //wywoluje ResetSpace klasy Grid
            grid.ResetSpace();
         
            //przewidywana wartosc
            String expected = "";
            //wartosc uzyskkana przy ResetSpace dla this.GridSpace.button.getText()
            //tlumaczenie, metoda ResetSpace() zmienia wartosc pola klasy GridSpace Button.text na "";
            String actual = grid.button.getText();
         
            //Assert.AreEqual to metoda ktora sprawdza argument 1 z argumentem 2 (tutaj jest to expected i actual ), i porownuje ich wartosci
            //w tym przypadku na wartosciach string
            Assert.AreEqual(expected, actual);
        }
      
    }
}