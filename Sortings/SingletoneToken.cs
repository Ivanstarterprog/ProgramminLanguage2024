using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingLanguage2024.Sortings
{
    class Singletone<T> where T : new()
    {
        static private T _instance;
        private static object syncRoot = new Object();

        static public T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {

                        _instance = new T();
                    }
                }
                return _instance;
            }
        }

        public Singletone()
        {

        }
    }

    class CancelToken : Singletone<CancelToken>
    {
        async public Task Cancel()
        {
            cancellationTokenSource.Cancel();
            // Задержка для того, чтобы токен успел отмениться на множестве активных сортировок
            await Task.Delay(300);
            cancellationTokenSource.Dispose();
            cancellationTokenSource = new CancellationTokenSource();
        }
        public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    }
}
