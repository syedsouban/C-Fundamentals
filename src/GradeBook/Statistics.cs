using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum/Count;
            }
        }
        public char Letter
        {
            get
            {
                if (Average >= 90)
                {
                    return 'A';
                }
                else if (Average >= 80 && Average < 90)
                {
                    return 'B';
                }
                else if (Average >= 70 && Average < 80)
                {
                    return  'C';
                }
                else if (Average >= 60 && Average < 70)
                {
                    return  'C';
                }
                else if (Average >= 50 && Average < 60)
                {
                    return  'D';
                }
                else if (Average >= 40 && Average < 50)
                {
                    return  'E';
                }
                else
                {
                    return  'F';
                }
            }
        }
        public double Highest, Lowest;
        public double Sum;
        public double Count;
        public void Add(double number) {
            Sum+=number;
            Count+=1;
            Highest = Math.Max(Highest,number);
            Lowest = Math.Min(Lowest,number);
        }
        public Statistics() {
            this.Highest=double.MinValue;
            this.Lowest=double.MaxValue;
            Count = 0;
        }
        
    }
}