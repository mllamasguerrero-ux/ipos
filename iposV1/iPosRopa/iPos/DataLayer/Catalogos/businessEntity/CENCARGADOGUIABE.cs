
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CENCARGADOGUIABE
    {
        public CPERSONABE m_PersonaBE;

        public CPERSONAFIGURABE m_FigureBE;
        public CENCARGADOGUIABE()
        {
            m_PersonaBE = new CPERSONABE();
            m_FigureBE = new CPERSONAFIGURABE();
        }
    }
}