using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BlogApplication.Controllers
{
    public class TimeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public TimeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            if (_memoryCache.TryGetValue("time", out DateTime cacheTime) == false)
            {
                cacheTime = DateTime.Now;
                var cacheOptions = new MemoryCacheEntryOptions();
                cacheOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                _memoryCache.Set("time", cacheTime, cacheOptions);
            }
            ViewBag.Time = cacheTime;
            return View();
        }
    }
}
