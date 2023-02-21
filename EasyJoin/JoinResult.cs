namespace EasyJoin
{
    public class JoinResult<T1, T2>
    {
        public T1 A { get; set; }
        public T2 B { get; set; }

        public JoinResult(T1 t1, T2 t2)
        {
            A = t1;
            B = t2;
        }
    }
}
