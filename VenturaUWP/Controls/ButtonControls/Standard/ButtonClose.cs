namespace Ventura.Controls
{
    public class ButtonClose : SmartButton
    {
        // Black background close button: "M5,95h90V5H5V95z M27.5,35.7l8.2-8.2L50,41.8l14.3-14.3l8.2,8.2L58.2,50l14.3,14.3l-8.2,8.2L50,58.2L35.7,72.5l-8.2-8.2 L41.8,50L27.5,35.7z"

        public static string IconString
        {
            get { return "M 7 2 C 4.2504839 2 2 4.2504839 2 7 L 2 43 C 2 45.749516 4.2504839 48 7 48 L 43 48 C 45.749516 48 48 45.749516 48 43 L 48 7 C 48 4.2504839 45.749516 2 43 2 L 7 2 z M 7 4 L 43 4 C 44.668484 4 46 5.3315161 46 7 L 46 43 C 46 44.668484 44.668484 46 43 46 L 7 46 C 5.3315161 46 4 44.668484 4 43 L 4 7 C 4 5.3315161 5.3315161 4 7 4 z M 15.71875 14.28125 L 14.28125 15.71875 L 23.5625 25 L 14.28125 34.28125 L 15.71875 35.71875 L 25 26.4375 L 34.28125 35.71875 L 35.71875 34.28125 L 26.4375 25 L 35.71875 15.71875 L 34.28125 14.28125 L 25 23.5625 L 15.71875 14.28125 z"; }
        }

        public ButtonClose()
        {
            this.Label = "Close";
            this.PathData = ButtonClose.IconString;
        }

    }
}
