using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testMemCache
{
    class Program
    {
        const int MAX_KEY = 100000;
        const int THREAD_COUNT = 20;
        static void Main(string[] args)
        {
            testMicrosoft();
            testDictionary();
            
            Console.ReadLine();

        }
        static void runMultyThread(Action action, int threadCount)
        {
            Thread[] thArray = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                thArray[i] = new Thread(new ThreadStart(action));
                thArray[i].Start();
            }

            thArray.ToList().ForEach(t => t.Join());
        }


        static void testMicrosoft()
        {
            int startTime = System.Environment.TickCount;

            runMultyThread(() =>
            {
                IObjectCacheClient memCacheMicosoft = new CacheByMicrosoft();

                loadData(memCacheMicosoft);
                getData(memCacheMicosoft);
            }, THREAD_COUNT);

            int totalTime = System.Environment.TickCount - startTime;

            Console.WriteLine($"Total time for microsoft cache = {totalTime}");
        }

        static void testDictionary()
        {
            int startTime = System.Environment.TickCount;

            runMultyThread(() =>
            {
                IObjectCacheClient memCacheDictionary = new CacheByDictionary();

                loadData(memCacheDictionary);
                getData(memCacheDictionary);
            }, THREAD_COUNT);

            int totalTime = System.Environment.TickCount - startTime;

            Console.WriteLine($"Total time for dictionary cache = {totalTime}");
        }

        static void loadData(IObjectCacheClient cache)
        {
            for(int i = 0;i < MAX_KEY;i++)
            {
                var val = new string('D', 100);
                cache.Set(i.ToString(), val, null);
            }
        }

        static void getData(IObjectCacheClient cache)
        {
            for (int i = 0; i < MAX_KEY; i++)
            {                
                var val = cache.Get<string>(i.ToString());
            }
        }
    }


}
