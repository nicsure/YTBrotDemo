using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTBrotDemo
{
    internal class AFloat
    {
        private double db;
        private decimal dc;

        public static AFloat Zero = new();
        public static AFloat One = new() { db = 1, dc = 1 };
        public static AFloat Two = new() { db = 2, dc = 2 };

        public static bool HiPrecision
        {
            get => Mul == MulDouble;
            set
            {
                Mul = value ? MulDecimal : MulDouble;
                Div = value ? DivDecimal : DivDouble;
                Add = value ? AddDecimal : AddDouble;
                Sub = value ? SubDecimal : SubDouble;
            }
        }

        public static Action<AFloat, AFloat> Mul
        {
            get;
            private set;
        } = MulDouble;
        public static Action<AFloat, AFloat> Div
        {
            get;
            private set;
        } = DivDouble;
        public static Action<AFloat, AFloat> Add
        {
            get;
            private set;
        } = AddDouble;
        public static Action<AFloat, AFloat> Sub
        {
            get;
            private set;
        } = SubDouble;

        public double GetDouble => HiPrecision ? db : (double)dc;
        public decimal GetDecimal => HiPrecision ? dc : (decimal)db;

        public void Equalize()
        {
            if (HiPrecision)
                db = (double)dc;
            else
                dc = (decimal)db;
        }

        public void Set(double d)
        {
            db = d;
            dc = (decimal)d;
        }

        public void Set(decimal d)
        {
            dc = d;
            db = (double)d;
        }

        public AFloat() { }
        public AFloat(double d) => Set(d);
        public AFloat(decimal d) => Set(d);

        public static void MulDouble(AFloat a, AFloat b) => a.db *= b.db;
        public static void MulDecimal(AFloat a, AFloat b) => a.dc *= b.dc;
        public static void DivDouble(AFloat a, AFloat b) => a.db /= b.db;
        public static void DivDecimal(AFloat a, AFloat b) => a.dc /= b.dc;
        public static void AddDouble(AFloat a, AFloat b) => a.db += b.db;
        public static void AddDecimal(AFloat a, AFloat b) => a.dc += b.dc;
        public static void SubDouble(AFloat a, AFloat b) => a.db -= b.db;
        public static void SubDecimal(AFloat a, AFloat b) => a.dc -= b.dc;

    }
}
