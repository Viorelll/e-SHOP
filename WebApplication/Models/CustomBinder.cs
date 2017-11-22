using System;
using System.Web.Mvc;

namespace WebApplication.Models
{

    public class CustomBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            
            var typeValue = bindingContext.ValueProvider.GetValue("ModelType");

            var type = Type.GetType((string)typeValue.ConvertTo(typeof(string)), true);

            if (!typeof(ItemViewModel).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Bad Type");
            }

            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);

            return model;
        }

    }
}