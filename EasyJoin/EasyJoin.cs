using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyJoin
{
    public static class EasyJoin
    {
        public static IEnumerable<JoinResult<A,B>> InnerJoin<A, B, TKey>(this IEnumerable<A> enumerableA, IEnumerable<B> enumerableB, Func<A,TKey> elementA, Func<B, TKey> elementB)
        {
            return enumerableA.Join(enumerableB, elementA, elementB, (a, b) => new JoinResult<A,B>(a,b));
        }

        public static IEnumerable<JoinResult<A,B>> LeftJoin<A, B, TKey>(this IEnumerable<A> enumerableA, IEnumerable<B> enumerableB, Func<A, TKey> elementA, Func<B, TKey> elementB)
        {
            IEnumerable<A> allAInInnerJoin = enumerableA.InnerJoin(enumerableB, elementA, elementB).Select(x => x.A);
            IEnumerable<JoinResult<A,B>> allAExceptInallAInInnerJoin = enumerableA.Select<A,JoinResult<A,B>>((a) => new JoinResult<A, B>(a, default(B))).Where(x => !allAInInnerJoin.Contains(x.A));
            
            return enumerableA.InnerJoin(enumerableB, elementA, elementB).Union(allAExceptInallAInInnerJoin);
        }

        public static IEnumerable<JoinResult<A, B>> RightJoin<A, B, TKey>(this IEnumerable<A> enumerableA, IEnumerable<B> enumerableB, Func<A, TKey> elementA, Func<B, TKey> elementB)
        {
            IEnumerable<B> allBInInnerJoin = enumerableA.InnerJoin(enumerableB, elementA, elementB).Select(x => x.B);
            IEnumerable<JoinResult<A, B>> allBExceptInallBInInnerJoin = enumerableB.Select<B,JoinResult<A,B>>((b) => new JoinResult<A, B>(default(A), b)).Where(x => !allBInInnerJoin.Contains(x.B));
            return enumerableA.InnerJoin(enumerableB, elementA, elementB).Union(allBExceptInallBInInnerJoin);            
        }

        public static IEnumerable<JoinResult<A, B>> FullJoin<A, B, TKey>(this IEnumerable<A> enumerableA, IEnumerable<B> enumerableB, Func<A, TKey> elementA, Func<B, TKey> elementB)
        {
            IEnumerable<JoinResult<A, B>> innerJoin = enumerableA.InnerJoin(enumerableB, elementA, elementB);

            return enumerableA.LeftJoin(enumerableB, elementA, elementB).Union(enumerableA.RightJoin(enumerableB, elementA, elementB).Where(x => !innerJoin.Any(y => x.A != null && x.B != null && x.A.Equals(y.A) && x.B.Equals(y.B))));
        }

        public static IEnumerable<JoinResult<A, B>> CrossJoin<A, B>(this IEnumerable<A> enumerableA, IEnumerable<B> enumerableB)
        {
            return enumerableA.SelectMany(a => enumerableB, (a, b) => new JoinResult<A, B>(a, b));
        }

        public static IEnumerable<JoinResult<A, A>> SelfJoin<A,TKey>(this IEnumerable<A> enumerableA, Func<A, TKey> elementA1, Func<A, TKey> elementA2)
        {
            return enumerableA.Join(enumerableA, elementA1, elementA2, (a, b) => new JoinResult<A, A>(a, b));
        }
    }
}
