namespace Educative.IO.Common
{
    public class Interval
    {
        public int start;
        public int end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public override string ToString()
        {
            return $"Start: {start}, End: {end}";
        }
    }
}
