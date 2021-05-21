using System.Runtime.InteropServices;

namespace Toolkit.Scanner
{
    public static class WiaError
    {
        public const int SEVERITY_SUCCESS = 0;
        public const int SEVERITY_ERROR = 1;
        public const int FACILITY_WIA = 33;
        public const int FACILITY_ITA = 4;

        public static readonly int WIA_ERROR_GENERAL_ERROR;
        public static readonly int WIA_ERROR_PAPER_JAM;
        public static readonly int WIA_ERROR_PAPER_EMPTY;
        public static readonly int WIA_ERROR_PAPER_PROBLEM;
        public static readonly int WIA_ERROR_OFFLINE;
        public static readonly int WIA_ERROR_BUSY;
        public static readonly int WIA_ERROR_WARMING_UP;
        public static readonly int WIA_ERROR_USER_INTERVENTION;
        public static readonly int WIA_ERROR_ITEM_DELETED;
        public static readonly int WIA_ERROR_DEVICE_COMMUNICATION;
        public static readonly int WIA_ERROR_INVALID_COMMAND;
        public static readonly int WIA_ERROR_INCORRECT_HARDWARE_SETTING;
        public static readonly int WIA_ERROR_DEVICE_LOCKED;
        public static readonly int WIA_ERROR_EXCEPTION_IN_DRIVER;
        public static readonly int WIA_ERROR_INVALID_DRIVER_RESPONSE;
        public static readonly int WIA_ERROR_COVER_OPEN;
        public static readonly int WIA_ERROR_LAMP_OFF;
        public static readonly int WIA_ERROR_DESTINATION;
        public static readonly int WIA_ERROR_NETWORK_RESERVATION_FAILED;
        public static readonly int WIA_STATUS_END_OF_MEDIA;
        public static readonly int WIA_S_NO_DEVICE_AVAILABLE;
        public static readonly int WIA_ERROR_NO_DEVICE_FOUND;
        public static readonly int COM_ERROR_CLASS_NOT_REGISTERED;

        static WiaError()
        {
            WIA_ERROR_GENERAL_ERROR = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 1);
            WIA_ERROR_PAPER_JAM = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 2);
            WIA_ERROR_PAPER_EMPTY = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 3);
            WIA_ERROR_PAPER_PROBLEM = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 4);
            WIA_ERROR_OFFLINE = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 5);
            WIA_ERROR_BUSY = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 6);
            WIA_ERROR_WARMING_UP = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 7);
            WIA_ERROR_USER_INTERVENTION = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 8);
            WIA_ERROR_ITEM_DELETED = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 9);
            WIA_ERROR_DEVICE_COMMUNICATION = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 10);
            WIA_ERROR_INVALID_COMMAND = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 11);
            WIA_ERROR_INCORRECT_HARDWARE_SETTING = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 12);
            WIA_ERROR_DEVICE_LOCKED = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 13);
            WIA_ERROR_EXCEPTION_IN_DRIVER = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 14);
            WIA_ERROR_INVALID_DRIVER_RESPONSE = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 15);
            WIA_ERROR_COVER_OPEN = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 16);
            WIA_ERROR_LAMP_OFF = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 17);
            WIA_ERROR_DESTINATION = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 18);
            WIA_ERROR_NETWORK_RESERVATION_FAILED = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 19);
            WIA_ERROR_NO_DEVICE_FOUND = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 107);
            WIA_STATUS_END_OF_MEDIA = MakeHresult(SEVERITY_SUCCESS, FACILITY_WIA, 1);
            WIA_S_NO_DEVICE_AVAILABLE = MakeHresult(SEVERITY_ERROR, FACILITY_WIA, 21);
         

            COM_ERROR_CLASS_NOT_REGISTERED = MakeHresult(SEVERITY_ERROR, FACILITY_ITA, 340);
        }

        public static string GetErrorMessage(COMException ce)
        {
            //These error messages come from the WIA documenation.
            if (ce.ErrorCode == WIA_ERROR_GENERAL_ERROR) { return "Неизвестная ошибка c Windows Image Acquisition (WIA) устройством."; }
            if (ce.ErrorCode == WIA_ERROR_PAPER_JAM) { return "Бумага застряла в автоподатчик сканера."; }
            if (ce.ErrorCode == WIA_ERROR_PAPER_EMPTY) { return "Пользователь запрашивал сканирования но нет документа в податчик оригиналов."; }
            if (ce.ErrorCode == WIA_ERROR_PAPER_PROBLEM) { return "Неопределенная проблема возникла с подачей документов в сканере."; }
            if (ce.ErrorCode == WIA_ERROR_OFFLINE) { return "WIA устройства не подключено к сети."; }
            if (ce.ErrorCode == WIA_ERROR_BUSY) { return "Устройство WIA занят."; }
            if (ce.ErrorCode == WIA_ERROR_WARMING_UP) { return "Устройство WIA разогревается."; }
            if (ce.ErrorCode == WIA_ERROR_USER_INTERVENTION) { return "Неизвестная ошибка произошла с устройством WIA, которая требует вмешательства пользователя, пользователь должен убедиться, что устройство включено, в Интернете, и все кабели подключены правильно."; }
            if (ce.ErrorCode == WIA_ERROR_ITEM_DELETED) { return "Устройство WIA был удален Он больше не может быть доступно.."; }
            if (ce.ErrorCode == WIA_ERROR_DEVICE_COMMUNICATION) { return "Неизвестная ошибка произошла при попытке связи с устройством WIA."; }
            if (ce.ErrorCode == WIA_ERROR_INVALID_COMMAND) { return "Устройство не поддерживает эту команду."; }
            if (ce.ErrorCode == WIA_ERROR_INCORRECT_HARDWARE_SETTING) { return "Неправильная настройка устройства WIA."; }
            if (ce.ErrorCode == WIA_ERROR_DEVICE_LOCKED) { return "Головка сканера заблокирована."; }
            if (ce.ErrorCode == WIA_ERROR_EXCEPTION_IN_DRIVER) { return "Драйвер устройства выдал исключение."; }
            if (ce.ErrorCode == WIA_ERROR_INVALID_DRIVER_RESPONSE) { return "Ответ от драйвера является недействительным."; }
            if (ce.ErrorCode == WIA_S_NO_DEVICE_AVAILABLE) { return "Ни одно устройство WIA выбранного типа не доступно."; }

            //These error messages are totally made up because they don't appear in the
            //documentation but are defined in WiaDef.h
            if (ce.ErrorCode == WIA_ERROR_COVER_OPEN) { return "Крышка устройства открыта."; }
            if (ce.ErrorCode == WIA_ERROR_LAMP_OFF) { return "Лампа устройства не горит."; }
            if (ce.ErrorCode == WIA_ERROR_DESTINATION) { return "Является недействительным назначения."; }
            if (ce.ErrorCode == WIA_ERROR_NETWORK_RESERVATION_FAILED) { return "Ошибка в сети."; }
            if (ce.ErrorCode == WIA_STATUS_END_OF_MEDIA) { return "Конец СМИ достигнута."; }
            if (ce.ErrorCode == WIA_ERROR_NO_DEVICE_FOUND){return "Сканер не найден";}
            //Watch for the specific error that means that the Wia Automation library is not installed.
            if (ce.ErrorCode == COM_ERROR_CLASS_NOT_REGISTERED) { return ce.Message + "\r\n Убедитесь что  WIA Automation Library 2.0 установлена и зарегистрирована."; }

            //If it's not a WIA error then just return the message we got from COM.
            return ce.Message;
        }

        private static int MakeHresult(int severity, int facility, int code)
        {
            //Code ripped straight out of the MAKEHRESULT macro defined in WinErr.h
            return (int)(((ulong)(severity) << 31) | ((ulong)(facility) << 16) | ((ulong)(code)));
        }
    }
}
