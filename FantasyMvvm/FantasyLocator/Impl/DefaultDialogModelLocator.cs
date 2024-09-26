using FantasyMvvm.FantasyDialogRegister;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyLocator.Impl;

public class DefaultDialogModelLocator : DialogModelLocatorBase
{

    private readonly IServiceProvider _provider;

    public DefaultDialogModelLocator(IDialogRegister dialogRegister, IServiceProvider provider) : base(dialogRegister)
    {
        _provider = provider;
    }

    protected override DialogModelElement Parse(DialogModel dialogModel)
    {
        try
        {

            object dialogType = _provider.GetRequiredService(dialogModel.Popup);
            if (dialogModel.PM != null)
            {
                object dialogModelType = _provider.GetRequiredService(dialogModel.PM);
                DialogModelElement element = new DialogModelElement()
                {
                    Dialog = dialogType,
                    DialogModel = dialogModelType
                };
                return element;
            }
            else
            {
                DialogModelElement element = new DialogModelElement()
                {
                    Dialog = dialogType
                };
                return element;
            }



        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}