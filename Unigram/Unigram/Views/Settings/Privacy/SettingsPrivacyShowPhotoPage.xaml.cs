﻿using Telegram.Td.Api;
using Unigram.ViewModels.Delegates;
using Unigram.ViewModels.Settings;
using Unigram.ViewModels.Settings.Privacy;
using Windows.UI.Xaml;

namespace Unigram.Views.Settings.Privacy
{
    public sealed partial class SettingsPrivacyShowPhotoPage : HostedPage, IUserDelegate
    {
        public SettingsPrivacyShowPhotoViewModel ViewModel => DataContext as SettingsPrivacyShowPhotoViewModel;

        public SettingsPrivacyShowPhotoPage()
        {
            InitializeComponent();
            Title = Strings.Resources.PrivacyProfilePhoto;
        }

        #region Delegate

        public void UpdateUser(Chat chat, User user, bool secret) { }

        public void UpdateUserFullInfo(Chat chat, User user, UserFullInfo fullInfo, bool secret, bool accessToken)
        {
            if (fullInfo != null)
            {
                UpdatePhoto.Content = fullInfo.PublicPhoto == null
                    ? Strings.Resources.SetPhotoForRest
                    : Strings.Resources.UpdatePhotoForRest;
                
                RemovePhoto.Visibility = fullInfo.PublicPhoto == null
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }
        }

        public void UpdateUserStatus(Chat chat, User user) { }

        #endregion

        #region Binding

        private Visibility ConvertNever(PrivacyValue value)
        {
            return value is PrivacyValue.AllowAll or PrivacyValue.AllowContacts ? Visibility.Visible : Visibility.Collapsed;
        }

        private Visibility ConvertAlways(PrivacyValue value)
        {
            return value is PrivacyValue.AllowContacts or PrivacyValue.DisallowAll ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

    }
}
