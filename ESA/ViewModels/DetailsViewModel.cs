using ESA.MarkupExtensions;
using ESA.Models.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ESA.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public Procedure Procedure { get; set; }
        public Command LoadProcedureCommand{ get; set; }

        //VideoPlayer
        public TimeSpan VideoPosition { get; set; }
        public string VideoName { get; set; }
        public bool VideoIsProcedure { get; set; }

        public DetailsViewModel(Procedure proc)
        {
            Procedure = proc;

            GetSteps(proc);
            GetComplications(proc);
        }

        // STEPS
        public void GetSteps(Procedure proc)
        {
            int stepNo = 1;
            foreach (var step in proc.Steps)
            {
                step.Number = stepNo;
                stepNo++;
                if (!string.IsNullOrEmpty(step.DiagramURL) && IsValidURI(step.DiagramURL))
                {
                    step.HasDiagram = true;
                    Uri diagramUri = new Uri(step.DiagramURL);
                    step.Diagram = new Diagram()
                    {
                        Thumbnail = ImageSource.FromUri(diagramUri),
                        VideoSource = ""
                    };
                }
            }
        }

        // COMPLICATIONS
        public void GetComplications(Procedure proc)
        {
            foreach (var complication in proc.Complications)
            {
                if (!string.IsNullOrEmpty(complication.DiagramURL) && IsValidURI(complication.DiagramURL))
                {
                    complication.HasDiagram = true;
                    Uri diagramUri = new Uri(complication.DiagramURL);
                    complication.Diagram = new Diagram()
                    {
                        Thumbnail = ImageSource.FromUri(diagramUri),
                        VideoSource = ""
                    };
                }
            }
        }

        // CHECK URI
        public bool IsValidURI(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                return false;
            }
            return true;
        }
    }
}
