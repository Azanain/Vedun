public static class EventManager
{
    public delegate void IntEventmanagerBoolDel(bool isIt);
    public static event IntEventmanagerBoolDel ThrewAxeEvent;

    public delegate void IntEventmanagerDel();
    public static event IntEventmanagerDel GetSphereEvent;
    public static event IntEventmanagerDel UpgradeAxeEvent;
    public static event IntEventmanagerDel MessageNeedMorePowerEvent;
    public static event IntEventmanagerDel AxeComeBackEvent;

    public delegate void IntEventmanagerIntDel(int number);
    public static event IntEventmanagerIntDel UpdateTextImproveEvent;
  
    public static void ThrewAxe(bool isIt)
    { ThrewAxeEvent?.Invoke(isIt); }

    public static void GetSphere()
    { GetSphereEvent?.Invoke(); }

    public static void UpgradeAxe()
    { UpgradeAxeEvent?.Invoke(); }

    public static void MessageNeedMorePower()
    { MessageNeedMorePowerEvent?.Invoke(); }
    public static void UpdateTextImprove(int number)
    { UpdateTextImproveEvent?.Invoke(number); }
    public static void AxeComeBack()
    { AxeComeBackEvent?.Invoke(); }
}
