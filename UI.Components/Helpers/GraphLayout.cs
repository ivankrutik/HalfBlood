namespace UI.Components.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using GraphSharp.Controls;
    using ParusModelLite.CommonDomain;
    using QuickGraph;

    public class GraphLayout : GraphLayout<Vertex, Edge, Graph>
    {
    }
    public class Graph : BidirectionalGraph<Vertex, Edge>
    {
        public Graph() { }

        public Graph(bool allowParallelEdges)
            : base(allowParallelEdges) { }

        public Graph(bool allowParallelEdges, int vertexCapacity)
            : base(allowParallelEdges, vertexCapacity) { }
    }
    public class Edge : Edge<Vertex>, INotifyPropertyChanged
    {
        private string _rn;

        public string RN
        {
            get { return _rn; }
            set
            {
                _rn = value;
                NotifyPropertyChanged("RN");
            }
        }

        public Edge(string rn, Vertex source, Vertex target)
            : base(source, target)
        {
            RN = rn;
        }


        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
    public class Vertex
    {
        public string UnitCode { get; set; }
        public long RnDocument { get; set; }
        public long Rn { get; set; }
        public bool IsLeaf { get; set; }
    }
    enum TypeAlgoritm
    {
        BoundedFR,
        Circular,
        CompoundFDP,
        EfficientSugiyama,
        FR,
        ISOM,
        KK,
        LinLog,
        Tree
    }
    public class GraphHelper : INotifyPropertyChanged
    {
        #region private Fileds
        private readonly List<Vertex> _vertexs = new List<Vertex>();
        private IList<LinkDto> _data;
        private Graph _graph;
        public readonly List<string> LayoutAlgorithmTypes = new List<string>();
        #endregion

        public Graph Graph
        {
            get
            {
                return _graph;
            }
            private set
            {
                _graph = value;
                //NotifyPropertyChanged("Graph");
            }
        }

        public GraphHelper()
        {
            Graph = new Graph(true);

            var d = Enum.GetValues(typeof(TypeAlgoritm));
            foreach (var elem in d)
            {
                LayoutAlgorithmTypes.Add(elem.ToString());
            }

        }

        public void SetData(IList<LinkDto> data)
        {
            _data = data;
            GraphClear();
            SetGraphVertex();
            SetGraphEdge();
        }

        private void GraphClear()
        {
            //Graph.Clear();

            //var ver = Graph.Vertices.ToList();
            //foreach (var elem in ver)
            //{
            //    Graph.RemoveVertex(elem);
            //}
            //var edg = Graph.Edges.ToList();
            //foreach (var elem in edg)
            //{
            //    Graph.RemoveEdge(elem);
            //}
            _vertexs.Clear();
            Graph = new Graph(true);


        }

        private void SetGraphVertex()
        {

            IEnumerable<long> ind = _data.Select(x => x.InDocument).Distinct();
            IEnumerable<long> outd = _data.Select(x => x.OutDocument).Distinct();
            ind = ind.Union(outd);

            foreach (var elem1 in ind)
            {
                foreach (var elem in _data)
                {
                    var vertex = new Vertex { Rn = elem.Rn, IsLeaf = elem.IsLeaf != 0 };
                    if (elem.InDocument == elem1)
                    {
                        vertex.RnDocument = elem.InDocument;
                        vertex.UnitCode = elem.InUnitCode;
                        _vertexs.Add(vertex);
                        break;
                    }
                    if (elem.OutDocument == elem1)
                    {
                        vertex.RnDocument = elem.OutDocument;
                        vertex.UnitCode = elem.OutUnitCode;
                        _vertexs.Add(vertex);
                        break;
                    }

                }
            }

            foreach (var elem in _vertexs)
            {
                Graph.AddVertex(elem);
            }

        }
        private void SetGraphEdge()
        {
            foreach (var elem in _vertexs)
            {
                foreach (var elem1 in _data)
                {
                    if (elem.RnDocument == elem1.InDocument)
                    {
                        foreach (var elem2 in _vertexs)
                        {
                            if (elem2.RnDocument == elem1.OutDocument)
                            {
                                AddNewGraphEdge(elem, elem2);
                            }
                        }
                    }
                }
            }
        }
        private Edge AddNewGraphEdge(Vertex from, Vertex to)
        {
            var edgeString = string.Format("{0}-{1} Connected", from.Rn, to.Rn);

            var newEdge = new Edge(edgeString, from, to);
            Graph.AddEdge(newEdge);
            return newEdge;
        }
        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
