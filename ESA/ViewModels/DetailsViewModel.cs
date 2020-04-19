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
            if (proc != null)
            {
                GetSteps(proc);
                GetComplications(proc);
                GetHistory(proc);
                GetReferences(proc);
            }

        }

        // STEPS
        public void GetSteps(Procedure proc)
        {
            int stepNo = 1;

            proc.Steps.Sort(delegate(Step x, Step y)
            {
                if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                else if (x.Number.ToString() == null) return -1;
                else if (y.Number.ToString() == null) return 1;
                else return x.Number.CompareTo(y.Number);
            });

            foreach (var step in proc.Steps)
            {
                step.Number = stepNo;
                stepNo++;
                if (!string.IsNullOrEmpty(step.DiagramURL) && IsValidURI(step.DiagramURL))
                {
                    step.HasDiagram = true;
                    UriImageSource diagramUri = new UriImageSource { Uri = new Uri(step.DiagramURL), CachingEnabled = true };
                    step.Diagram = new Diagram()
                    {
                        Thumbnail = diagramUri,
                        VideoSource = ""
                    };
                }
            }
        }

        // VARIATIONS
        public void GetVariations(Procedure proc)
        {
            proc.Variations.Sort(delegate (Variation x, Variation y)
            {
                if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                else if (x.Number.ToString() == null) return -1;
                else if (y.Number.ToString() == null) return 1;
                else return x.Number.CompareTo(y.Number);
            });
            foreach (var complication in proc.Complications)
            {
                if (!string.IsNullOrEmpty(complication.DiagramURL) && IsValidURI(complication.DiagramURL))
                {
                    complication.HasDiagram = true;
                    UriImageSource diagramUri = new UriImageSource { Uri = new Uri(complication.DiagramURL), CachingEnabled = true };
                    complication.Diagram = new Diagram()
                    {
                        Thumbnail = diagramUri,
                        VideoSource = ""
                    };
                }
            }
        }

        // COMPLICATIONS
        public void GetComplications(Procedure proc)
        {
            proc.Complications.Sort(delegate (Complication x, Complication y)
            {
                if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                else if (x.Number.ToString() == null) return -1;
                else if (y.Number.ToString() == null) return 1;
                else return x.Number.CompareTo(y.Number);
            });
            foreach (var complication in proc.Complications)
            {
                if (!string.IsNullOrEmpty(complication.DiagramURL) && IsValidURI(complication.DiagramURL))
                {
                    complication.HasDiagram = true;
                    UriImageSource diagramUri = new UriImageSource { Uri = new Uri(complication.DiagramURL), CachingEnabled=true };
                    complication.Diagram = new Diagram()
                    {
                        Thumbnail = diagramUri,
                        VideoSource = ""
                    };
                }
            }
        }

        // HISTORY
        public void GetHistory(Procedure proc)
        {
            proc.History.Sort(delegate (History x, History y)
            {
                if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                else if (x.Number.ToString() == null) return -1;
                else if (y.Number.ToString() == null) return 1;
                else return x.Number.CompareTo(y.Number);
            });
        }

        // REFERENCES
        public void GetReferences(Procedure proc)
        {
            int refNo = 1;

            proc.References.Sort(delegate (Reference x, Reference y)
            {
                if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                else if (x.Number.ToString() == null) return -1;
                else if (y.Number.ToString() == null) return 1;
                else return x.Number.CompareTo(y.Number);
            });

            foreach (var reference in proc.References)
            {
                reference.Number = refNo;
                refNo++;
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
