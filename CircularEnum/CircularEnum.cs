using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerator
{
   public struct CircularEnum<T> where T : Enum
   {
        private T Enumerator;
        private static int? ElementCount;

        public CircularEnum(T enumerator)
        {
            Enumerator = enumerator;
            InitElementCount();
        }

        public static void InitElementCount()
        {
            if (ElementCount == null)
            {
                ElementCount = Enum.GetNames(typeof(T)).Length;
            }
        }

        public static implicit operator T(CircularEnum<T> circEnum) => circEnum.Enumerator;

        public static implicit operator CircularEnum<T>(T enumerator) => new CircularEnum<T>(enumerator);

        public static CircularEnum<T> operator +(CircularEnum<T> circEnum, int num)
        {
            InitElementCount();
            int newEnumPos = (int)(object)circEnum.Enumerator + num;
            if (newEnumPos >= ElementCount)
            {
                return new CircularEnum<T>((T)(object)(newEnumPos % ElementCount));
            }
            return new CircularEnum<T>((T)(object)newEnumPos);
        }
        public static CircularEnum<T> operator ++(CircularEnum<T> circEnum)
        {
            InitElementCount();
            int newEnumPos = (int)(object)circEnum.Enumerator + 1;
            if (newEnumPos == ElementCount)
            {
                return new CircularEnum<T>((T)(object)0);
            }
            return new CircularEnum<T>((T)(object)newEnumPos);
        }

        public static CircularEnum<T> operator -(CircularEnum<T> circEnum, int num)
        {
            InitElementCount();
            int newEnumPos = (int)(object)circEnum.Enumerator - num;
            if (newEnumPos < 0)
            {
                return new CircularEnum<T>((T)(object)(newEnumPos % ElementCount));
            }
            return new CircularEnum<T>((T)(object)newEnumPos);
        }
        public static CircularEnum<T> operator --(CircularEnum<T> circEnum)
        {
            InitElementCount();
            int newEnumPos = (int)(object)circEnum.Enumerator - 1;
            if (newEnumPos < 0)
            {
                return new CircularEnum<T>((T)(object)(ElementCount - 1));
            }
            return new CircularEnum<T>((T)(object)newEnumPos);
        }
    }
}
