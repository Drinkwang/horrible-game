using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.script.Utils
{
    public class HEnum : IComparable<HEnum>, IEquatable<HEnum>
    {
        static int counter = -1;
        private static Hashtable hashTable = new Hashtable();

        protected static List<HEnum> members = new List<HEnum>();

        private string Name { get; set; }
        private int Value { get; set; }

        protected HEnum(string name)
        {
            this.Name = name;
            this.Value = ++counter;
            members.Add(this);
            if (!hashTable.ContainsKey(this.Value))
            {

                hashTable.Add(this.Value, this);
            }


        }

        protected HEnum(string name, int value)
        {

            this.Name = name;
            this.Value = value;
            members.Add(this);
            if (!hashTable.ContainsKey(this.Value))
            {

                hashTable.Add(this.Value, this);
            }

        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        public static explicit operator HEnum(int i)
        {
            if (hashTable.ContainsKey(i))
            {
                return (HEnum)members[i];
                ;
            }
            return new HEnum(i.ToString(), i);

        }

        public static explicit operator int(HEnum e)
        {
            return e.Value;

        }

        public static void ForEach(Action<HEnum> action)
        {
            foreach (HEnum item in members)
            {
                action(item);
            }
        }


        public int CompareTo(HEnum other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public bool Equals(HEnum other)
        {
            return this.Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HEnum))
                return false;
            return this.Value == ((HEnum)obj).Value;
        }

        public override int GetHashCode()
        {

            HEnum std = (HEnum)hashTable[this.Value];
            if (std.Name == this.Name)
                return base.GetHashCode();
            else
                return std.GetHashCode();
        }

        public static bool operator !=(HEnum e1, HEnum e2)
        {
            return e1.Value != e2.Value;
        }

        public static bool operator <(HEnum e1, HEnum e2)
        {
            return e1.Value < e2.Value;
        }

        public static bool operator <=(HEnum e1, HEnum e2)
        {
            return e1.Value <= e2.Value;
        }

        public static bool operator ==(HEnum e1, HEnum e2)
        {
            return e1.Value == e2.Value;
        }

        public static bool operator >(HEnum e1, HEnum e2)
        {
            return e1.Value > e2.Value;
        }

        public static bool operator >=(HEnum e1, HEnum e2)
        {
            return e1.Value >= e2.Value;
        }

    }
}
