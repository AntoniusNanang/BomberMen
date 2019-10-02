namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Effects/Custom/Gradient", 100)]
    public class GradientTest : BaseMeshEffect
    {
        public Color32 Color1 = Color.yellow;
        public Color32 Color2 = Color.red;
        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive()) return;
            UIVertex v = new UIVertex();
            int idx = 0;
            for (int i = 0; i < vh.currentVertCount; i++)
            {
                vh.PopulateUIVertex(ref v, i);
                //switch (idx)
                //{
                //    case 0: v.color = new Color(0,0,0,0.2f); break;
                //    case 1: v.color = Color.black; break;
                //    //case 2: v.color = Color.black; break;
                //}
                //縦のグラデーション
                v.color = (idx == 0 || idx == 3) ? Color1 : Color2;
                //横のグラデーション
                v.color = (idx == 0 || idx == 1) ? Color1 : Color2;
                if (++idx >= 4) { idx = 0; }
                vh.SetUIVertex(v, i);
            }
        }
    }
}