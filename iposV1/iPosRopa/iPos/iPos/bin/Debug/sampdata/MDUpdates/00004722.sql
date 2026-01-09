EXECUTE BLOCK
AS
BEGIN

       update derechos set dr_derecho = 308 where dr_derecho = 350;
       update derechos set dr_derecho = 309 where dr_derecho = 351;
       update derechos set dr_derecho = 310 where dr_derecho = 352;
       update derechos set dr_derecho = 311 where dr_derecho = 353;

       update menuitems set mn_id = 308, mn_derecho = 308 where mn_id = 350;
       update menuitems set mn_id = 309, mn_derecho = 309, mn_idparent = 308 where mn_id = 351;
       update menuitems set mn_id = 310, mn_derecho = 310, mn_idparent = 308 where mn_id = 352;
       update menuitems set mn_id = 311, mn_derecho = 311, mn_idparent = 308 where mn_id = 353;


       update perfil_der set pd_derecho = 308 where pd_derecho = 350;
       update perfil_der set pd_derecho = 309 where pd_derecho = 351;
       update perfil_der set pd_derecho = 310 where pd_derecho = 352;
       update perfil_der set pd_derecho = 311 where pd_derecho = 353;
	
	

  

END