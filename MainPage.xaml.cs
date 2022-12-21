using Calculator2022.Logic;

namespace Calculator2022;

public partial class MainPage : ContentPage
{
    Calculator calc = new Calculator();

    public MainPage()
    {
        InitializeComponent();
    }

    private void Clear(object sender, EventArgs e)
    {
        calc.Press("C");
        lblScreen.Text = calc.Screen;
    }
    private void Result(object sender, EventArgs e)
    {
        calc.Press("=");
        lblScreen.Text = calc.Screen;
    }
    private void Sign(object sender, EventArgs e)
    {
        calc.Press("-/+");
        lblScreen.Text = calc.Screen;
    }
    private void Plus(object sender, EventArgs e)
    {
        calc.Press("+");
        lblScreen.Text = calc.Screen;
    }
    private void Minus(object sender, EventArgs e)
    {
        calc.Press("-");
        lblScreen.Text = calc.Screen;
    }
    private void Multiply(object sender, EventArgs e)
    {
        calc.Press("*");
        lblScreen.Text = calc.Screen;
    }
    private void Divide(object sender, EventArgs e)
    {
        calc.Press("/");
        lblScreen.Text = calc.Screen;
    }
    private void Dot(object sender, EventArgs e)
    {
        calc.Press(".");
        lblScreen.Text = calc.Screen;
    }
    private void NumOne(object sender, EventArgs e)
    {
        calc.Press("1");
        lblScreen.Text = calc.Screen;
    }
    private void NumTwo(object sender, EventArgs e)
    {
        calc.Press("2");
        lblScreen.Text = calc.Screen;
    }
    private void NumThree(object sender, EventArgs e)
    {
        calc.Press("3");
        lblScreen.Text = calc.Screen;
    }
    private void NumFour(object sender, EventArgs e)
    {
        calc.Press("4");
        lblScreen.Text = calc.Screen;
    }
    private void NumFive(object sender, EventArgs e)
    {
        calc.Press("5");
        lblScreen.Text = calc.Screen;
    }
    private void NumSix(object sender, EventArgs e)
    {
        calc.Press("6");
        lblScreen.Text = calc.Screen;
    }
    private void NumSeven(object sender, EventArgs e)
    {
        calc.Press("7");
        lblScreen.Text = calc.Screen;
    }
    private void NumEight(object sender, EventArgs e)
    {
        calc.Press("8");
        lblScreen.Text = calc.Screen;
    }
    private void NumNine(object sender, EventArgs e)
    {
        calc.Press("9");
        lblScreen.Text = calc.Screen;
    }
    private void NumZero(object sender, EventArgs e)
    {
        calc.Press("0");
        lblScreen.Text = calc.Screen;
    }
}
