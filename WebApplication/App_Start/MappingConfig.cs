using DomainModel.Models;
using DomainModel.Shop;
using WebApplication.Models;


namespace WebApplication.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {

            AutoMapper.Mapper.Initialize(cfg => {

                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<UserViewModel, User>();
                    cfg.CreateMap<Customer, CustomerViewModel>();
                    cfg.CreateMap<CustomerViewModel, Customer>();

                    cfg.CreateMap<Item, ItemViewModel>()
                      .ForMember(m => m.Category, opt => opt.MapFrom(x => (int) x.Category))
                        .Include<Monitor, MonitorViewModel>()
                        .Include<CPU, CpuViewModel>()
                        .Include<RAM, RamViewModel>()
                        .Include<Keyboard, KeyboardViewModel>()
                        .Include<Laptop, LaptopViewModel>()
                        .Include<Motherboard, MotherboardViewModel>()
                        .Include<Mouse, MouseViewModel>()
                        .Include<Webcam, WebcamViewModel>();

                    cfg.CreateMap<Monitor, MonitorViewModel>();
                    cfg.CreateMap<CPU, CpuViewModel>();
                    cfg.CreateMap<RAM, RamViewModel>();
                    cfg.CreateMap<Keyboard, KeyboardViewModel>();
                    cfg.CreateMap<Laptop, LaptopViewModel>();
                    cfg.CreateMap<Motherboard, MotherboardViewModel>();
                    cfg.CreateMap<Mouse, MouseViewModel>();
                    cfg.CreateMap<Webcam, WebcamViewModel>();


                    cfg.CreateMap<ItemViewModel, Item>()
                      .ForMember(m => m.Category, opt => opt.MapFrom(x => (int)x.Category))
                        .Include<MonitorViewModel, Monitor>()
                        .Include<CpuViewModel, CPU>()
                        .Include<RamViewModel, RAM>()
                        .Include<KeyboardViewModel, Keyboard>()
                        .Include<LaptopViewModel, Laptop>()
                        .Include<MotherboardViewModel, Motherboard>()
                        .Include<MouseViewModel, Mouse>()
                        .Include<WebcamViewModel, Webcam>();

                    cfg.CreateMap<MonitorViewModel, Monitor>();
                    cfg.CreateMap<CpuViewModel, CPU>();
                    cfg.CreateMap<RamViewModel, RAM>();
                    cfg.CreateMap<KeyboardViewModel, Keyboard>();
                    cfg.CreateMap<LaptopViewModel, Laptop>();
                    cfg.CreateMap<MotherboardViewModel, Motherboard>();
                    cfg.CreateMap<MouseViewModel, Mouse>();
                    cfg.CreateMap<WebcamViewModel, Webcam>();


                cfg.CreateMap<BuyItem, BuyItemViewModel>();
                    cfg.CreateMap<Order, OrderViewModel>();
                    //cfg.CreateMap<Cart, CartViewModel>();


            });
        }
    }
}