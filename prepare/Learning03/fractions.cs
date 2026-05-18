using System.Diagnostics;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

     public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

     public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
        SetFractionBotttom(bottom);
    }

    public void SetFractionTop(int top)
    {
        _top = top;
    }

    public void SetFractionBotttom(int bottom)
    {
        if (bottom == 0)
        {
            _bottom = 1;
        }
        else 
        {
            _bottom = bottom;
        }       
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetFractionValue()
    {
        return ((double)_top / _bottom);
    }

    public int GetFractionTop()
    {
        return _top;
    }

    public int GetFractionBottom()
    {
        return _bottom;
    }





}