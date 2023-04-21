using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DFToys.Common
{
    public sealed class StringBuilderPool
    {
        public static readonly StringBuilderPool Shared = new StringBuilderPool();

        private readonly ObjectPool<StringBuilder> _spb;

        public StringBuilderPool() : this(4096, int.MaxValue)
        {
        }

        public StringBuilderPool(int defaultStringBuilderCapacity) : this(defaultStringBuilderCapacity, int.MaxValue)
        {
        }

        public StringBuilderPool(
            int defaultStringBuilderCapacity,
            int defaultStringBuilderMaxCapacity)
        {
            _spb = ObjectPool.Create(new PooledStringBuilderPolicy(
                defaultStringBuilderCapacity,
                defaultStringBuilderMaxCapacity));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StringBuilder Get() => _spb.Get();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(StringBuilder sb) => _spb.Return(sb);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ReturnAndGetString(StringBuilder sb) { 
            var str= sb.ToString();
            _spb.Return(sb);
            return str;
        }

        private sealed class PooledStringBuilderPolicy : IPooledObjectPolicy<StringBuilder>
        {
            private readonly int _defaultStringBuilderCapacity;
            private readonly int _defaultStringBuilderMaxCapacity;

            public PooledStringBuilderPolicy(
                int defaultStringBuilderCapacity,
                int defaultStringBuilderMaxCapacity
                )
            {
                _defaultStringBuilderCapacity = defaultStringBuilderCapacity;
                _defaultStringBuilderMaxCapacity = defaultStringBuilderMaxCapacity;
            }

            public StringBuilder Create()
            {
                return new StringBuilder(_defaultStringBuilderCapacity, _defaultStringBuilderMaxCapacity);
            }

            public bool Return(StringBuilder obj)
            {
                obj.Clear();
                return true;
            }
        }
    }
}
