using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskC_
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public static class Server
        {
            static int count;

            private static ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

            static Server()
            {
                count = 0;
            }

            public static int GetCount()
            {
                return count;
            }

            public static void AddToCount()
            {
                cacheLock.EnterUpgradeableReadLock();
                cacheLock.EnterWriteLock();
                cacheLock.EnterReadLock();

                try
                {
                    count++;
                }
                finally
                {
                    cacheLock.ExitUpgradeableReadLock();
                    cacheLock.ExitReadLock();
                    cacheLock.ExitWriteLock();
                }
            }
        }
    }
}