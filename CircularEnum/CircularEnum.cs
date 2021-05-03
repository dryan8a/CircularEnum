using System;
using System.Collections.Generic;
using System.Text;

namespace CircularEnumerator
{
   public struct CircularEnum<T> where T : Enum
   {
        private T Enumeration;
        private static int ElementCount;

        public CircularEnum(T enumerator)
        {
            Enumeration = enumerator;
        }

        static CircularEnum()
        {
            ElementCount = Enum.GetNames(typeof(T)).Length;
        }

        public static implicit operator T(CircularEnum<T> circEnum) => circEnum.Enumeration;

        public static implicit operator CircularEnum<T>(T enumerator) => new CircularEnum<T>(enumerator);

        public static CircularEnum<T> operator +(CircularEnum<T> circEnum, int num)
        {
            int newEnumPos = (int)(object)circEnum.Enumeration + num;
            if (newEnumPos >= ElementCount)
            {
                return new CircularEnum<T>((T)(object)(newEnumPos % ElementCount));
            }
            return new CircularEnum<T>((T)(object)newEnumPos);
        }
        public static CircularEnum<T> operator ++(CircularEnum<T> circEnum) => circEnum + 1;
        public static CircularEnum<T> operator -(CircularEnum<T> circEnum, int num) => circEnum + -num;
        public static CircularEnum<T> operator --(CircularEnum<T> circEnum) => circEnum - 1;
    }
}
