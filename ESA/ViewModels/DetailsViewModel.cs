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
                Task.Run(async() => {
                    await GetSteps(proc);
                    await GetVariations(proc);
                    await GetComplications(proc);
                    await GetHistory(proc);
                    await GetReferences(proc);
                }).ConfigureAwait(false);
            }

        }

        // STEPS
        async Task GetSteps(Procedure proc)
        {
            await Task.Run(() => {
                int stepNo = 1;
                proc.Steps.Sort(delegate (Step x, Step y)
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
            }).ConfigureAwait(false);  
        }

        // VARIATIONS
        async Task GetVariations(Procedure proc)
        {
            await Task.Run(() => {
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
            }).ConfigureAwait(false);
        }

        // COMPLICATIONS
        async Task GetComplications(Procedure proc)
        {
            await Task.Run(() => {
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
                        UriImageSource diagramUri = new UriImageSource { Uri = new Uri(complication.DiagramURL), CachingEnabled = true };
                        complication.Diagram = new Diagram()
                        {
                            Thumbnail = diagramUri,
                            VideoSource = ""
                        };
                    }
                }
            }).ConfigureAwait(false);
        }

        // HISTORY
        async Task GetHistory(Procedure proc)
        {
            await Task.Run(() => {
                //proc.History.Sort(delegate (History x, History y)
                //{
                //    if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                //    else if (x.Number.ToString() == null) return -1;
                //    else if (y.Number.ToString() == null) return 1;
                //    else return x.Number.CompareTo(y.Number);
                //});
            }).ConfigureAwait(false);
        }

        // REFERENCES
        async Task GetReferences(Procedure proc)
        {
            await Task.Run(() => {
                //int refNo = 1;
                //proc.References.Sort(delegate (Reference x, Reference y)
                //{
                //    if (x.Number.ToString() == null && y.Number.ToString() == null) return 0;
                //    else if (x.Number.ToString() == null) return -1;
                //    else if (y.Number.ToString() == null) return 1;
                //    else return x.Number.CompareTo(y.Number);
                //});
                //foreach (var reference in proc.References)
                //{
                //    reference.Number = refNo;
                //    refNo++;
                //}
            }).ConfigureAwait(false);
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
