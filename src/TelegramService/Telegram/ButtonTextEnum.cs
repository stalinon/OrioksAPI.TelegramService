namespace TelegramService.Telegram;

/// <summary>
///     Перечисление секций API
/// </summary>
internal enum ButtonSectionEnum
{
    SCHEDULE_SECTION = 0,
    TEACHER_SECTION = 1,
}

/// <summary>
///     Перечисление методов секции расписаний
/// </summary>
internal enum ButtonScheduleEnum
{
    GET_EMPTY_AUDITORIES = 0,
    GET_SCHEDULE = 1,
}

/// <summary>
///     Перечисление методов секции преподавателей
/// </summary>
internal enum ButtonTeacherEnum
{
    GET_TEACHER = 0,
}

/// <summary>
///     Класс маппинга для
///     <list type="bullet">
///         <item><see cref="ButtonSectionEnum"/></item>
///         <item><see cref="ButtonScheduleEnum"/></item>
///         <item><see cref="ButtonTeacherEnum"/></item>
///     </list>
/// </summary>
internal static class ButtonTextEnumMapping 
{
    /// <summary>
    ///     Маппинг для <see cref="ButtonSectionEnum"/>
    /// </summary>
    public static string Map(ButtonSectionEnum section) =>
        section switch
        {
            ButtonSectionEnum.SCHEDULE_SECTION => "Расписания 📝",
            ButtonSectionEnum.TEACHER_SECTION => "Преподаватели 👨‍🏫",
            _ => throw new ArgumentOutOfRangeException()
        };

    /// <summary>
    ///     Маппинг для <see cref="ButtonScheduleEnum"/>
    /// </summary>
    public static string Map(ButtonScheduleEnum section) =>
        section switch
        {
            ButtonScheduleEnum.GET_EMPTY_AUDITORIES => "Получить список пустых аудиторий 📝",
            ButtonScheduleEnum.GET_SCHEDULE => "Получить расписание по параметрам 📝",
            _ => throw new ArgumentOutOfRangeException()
        };

    /// <summary>
    ///     Маппинг для <see cref="ButtonTeacherEnum"/>
    /// </summary>
    public static string Map(ButtonTeacherEnum section) =>
        section switch
        {
            ButtonTeacherEnum.GET_TEACHER => "Поиск по преподавателям",
            _ => throw new ArgumentOutOfRangeException()
        };
}
