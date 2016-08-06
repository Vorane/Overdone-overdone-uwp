﻿using overdone_uwp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace overdone_uwp.ToastManager
{
    public static class ToastManger
    {
        public static void CreateToast(task NewTask)
        {
            ToastTemplateType toastType = ToastTemplateType.ToastText02;

            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastType);

            XmlNodeList toastTextElement = toastXml.GetElementsByTagName("text");
            toastTextElement[0].AppendChild(toastXml.CreateTextNode(NewTask.task_name));
            toastTextElement[1].AppendChild(toastXml.CreateTextNode("an hour left"));

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            //ToastNotification toast = new ToastNotification(toastXml);
            //ToastNotificationManager.CreateToastNotifier().Show(toast);
            //ToastNotificationManager.CreateToastNotifier().AddToSchedule()
            //ToastNotificationManager.CreateToastNotifier().AddToSchedule()
            var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, NewTask.task_deadline.AddHours(-1));
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(customAlarmScheduledToast);
            //toastNotifier.AddToSchedule(customAlarmScheduledToast);            
        }
        public static void CreateNewToast(task NewTask)
        {
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            var toastText = toastXml.GetElementsByTagName("text");
            (toastText[0] as XmlElement).InnerText = NewTask.task_name;
            (toastText[1] as XmlElement).InnerText = "Hurry! an hour left";
            var toast = new ToastNotification(toastXml);
            //toastNotifier.Show(toast);
            var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, NewTask.task_deadline.AddHours(-1));
            customAlarmScheduledToast.Id = NewTask.task_id.ToString();
            customAlarmScheduledToast.Tag = NewTask.task_id.ToString();
            toastNotifier.AddToSchedule(customAlarmScheduledToast);
        }
        public static void CreateCustomToast(task NewTask, DateTime RemindTime)
        {
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            var toastText = toastXml.GetElementsByTagName("text");
            (toastText[0] as XmlElement).InnerText = NewTask.task_name;
            (toastText[1] as XmlElement).InnerText = (NewTask.task_deadline.Subtract(DateTime.Now)).Hours.ToString() + " hours left";
            var toast = new ToastNotification(toastXml);
            
            //toastNotifier.Show(toast);
            var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, RemindTime);
            customAlarmScheduledToast.Id = NewTask.task_id.ToString();
            customAlarmScheduledToast.Tag = NewTask.task_id.ToString();
            toastNotifier.AddToSchedule(customAlarmScheduledToast);
        }
        public static void CreateCustomToastNow(task NewTask)
        {
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            var toastText = toastXml.GetElementsByTagName("text");
            (toastText[0] as XmlElement).InnerText = NewTask.task_name;
            (toastText[1] as XmlElement).InnerText = ( "due: "+ NewTask.task_deadline.Day.ToString()  +"-" + NewTask.task_deadline.Month.ToString() + "-" + NewTask.task_deadline.Year.ToString() );
            var toast = new ToastNotification(toastXml);
            //toastNotifier.Show(toast);
            var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, DateTime.Now.AddSeconds(2));
            customAlarmScheduledToast.Id = NewTask.task_id.ToString();
            customAlarmScheduledToast.Tag = NewTask.task_id.ToString();
            toastNotifier.AddToSchedule(customAlarmScheduledToast);
        }
        public static void UpdateToast(task NewTask)
        {
            try
            {
                try
                {
                    ToastNotificationManager.History.Remove(NewTask.task_id.ToString());
                }
                catch { }
                var toastNotifier = ToastNotificationManager.CreateToastNotifier();
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
                var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, DateTime.Now);
                customAlarmScheduledToast.Id = NewTask.task_id.ToString();
                customAlarmScheduledToast.Tag = NewTask.task_id.ToString();

                try
                {
                    toastNotifier.RemoveFromSchedule(customAlarmScheduledToast);
                }
                catch
                { }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
            }
            CreateNewToast(NewTask);
        }

        public static void DeleteToast(task NewTask)
        {
            try
            {
                try
                {
                    ToastNotificationManager.History.Remove(NewTask.task_id.ToString());
                }
                catch { }
                var toastNotifier = ToastNotificationManager.CreateToastNotifier();
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
                var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, DateTime.Now.AddSeconds(5));
                customAlarmScheduledToast.Id = NewTask.task_id.ToString();
                customAlarmScheduledToast.Tag = NewTask.task_id.ToString();

                var not = toastNotifier.GetScheduledToastNotifications();

                try
                {
                    ToastNotificationManager.CreateToastNotifier().RemoveFromSchedule(customAlarmScheduledToast);
                }
                catch
                { }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
            }            
        }
    }
}
