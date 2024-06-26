﻿using Core.Components;
using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.Registration.Verification
{
    /// <summary>
    /// Upload documents verification page
    /// </summary>
    public class VerifyAccountPage : BasePage
    {
        protected By headerBy = By.XPath("//h1[.='Verify Account']");
        protected By identityVerificationTabBy = By.Id("identity-verification-tab");
        protected By corporateAccountTabBy = By.Id("corporate-account-tab");
        protected By poaAndOtherDocumentsTabBy = By.Id("poa-tab");

        protected By mobileScanCardBy = By.Id("mobile-scan-card");
        protected By uploadFromDeviceCardBy = By.Id("upload-from-device-card");

        protected By qrStepsBy = By.CssSelector("div.scan-qr-code__steps");
        protected By qrCanvasBy = By.CssSelector("div[class*=qr-container] canvas");

        protected ButtonControl CloseButton => new ButtonControl(By.CssSelector("button.close-icon"));

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            WaitForVisible(headerBy, timeoutInSec: WaitTime.ThirtySec);
        }

        public bool IsDisplayed() => IsElementExist(headerBy, timeoutInSec: WaitTime.TenSec);

        public bool IsIdentityVerificationTabDisplayed() => IsElementExist(identityVerificationTabBy);
        public bool IsCorporateAccountDisplayed() => IsElementExist(corporateAccountTabBy);
        public bool IsPoaTabDisplayed() => IsElementExist(poaAndOtherDocumentsTabBy);

        public void OpenMobileScanCard()
        {
            var card = Driver.FindElement(mobileScanCardBy);
            card.Click();
            card.WaitForDisappear();
        }

        public void WaitTillMobileScanPageElementsAreDisplayed()
        {
            WaitForVisible(qrStepsBy);
            WaitForVisible(qrCanvasBy);
        }

        public void NavigateToMainPage()
        {
            CloseButton.Click();

            var modalDialog = new ModalDialog("You can continue another time from the point you stopped");
            modalDialog.WaitForLoading();
            modalDialog.SaveAndExit();
        }
    }
}
