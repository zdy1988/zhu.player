﻿namespace ZDY.LovePlayer.Services
{
    public interface IApplicationState
    {
        bool IsFullScreen { get; set; }

        bool IsConnectionInError { get; set; }

        bool IsMediaPlaying { get; set; }

        bool IsRootDialogOpen { get; set; }

        object RootDialogContent { get; set; }

        void ShowDialog(object content);

        void HideDialog();

        void ShowLoadingDialog(string message = null);

        void HideLoadingDialog();
    }
}