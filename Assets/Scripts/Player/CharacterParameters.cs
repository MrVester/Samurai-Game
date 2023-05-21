public static class CharacterParameters
{

    private static float dashCoolDown = 2f;
    public static float DashCoolDown
    {
        get { return dashCoolDown; }
        set { dashCoolDown = value; }

    }

    private static float attackCoolDown = 0;
    public static float AttackCoolDown
    {
        get { return attackCoolDown; }
        set { attackCoolDown = value; }
    }


    private static float dashSpeed = 20f;
    public static float DashSpeed
    {
        get { return dashSpeed; }
        set { dashSpeed = value; }
    }

    private static float dashTime = 0.1f;
    public static float DashTime
    {
        get { return dashTime; }
        set { dashTime = value; }
    }
}
