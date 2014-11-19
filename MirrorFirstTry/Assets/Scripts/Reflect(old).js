#pragma strict
   
    public static var i : int = 0;
    public var currentMaterial : Material;
    public var updateRate = 1.0;
    public var renderFromPosition : Transform;
    public var minz = -1.0;
    public var go : GameObject;
    public var cubemap : Cubemap;
   
    function Start () {
        renderFromPosition = transform;
        go = new GameObject("Camera"+i,Camera);
        go.camera.backgroundColor = Color.black;
        go.camera.cullingMask = ~(1<<8);
        go.camera.enabled = false;
        go.transform.rotation = Quaternion.identity;
        cubemap = new Cubemap (256, TextureFormat.ARGB32, false);      
        i++;
        currentMaterial = renderer.material;
    }
   
    function Update () {
        if(Time.time - updateRate > minz){
            minz = Time.time - Time.deltaTime;
            RenderMe();
           
        }
    }
   
    function RenderMe(){
        go.transform.position = renderFromPosition.position;
        if(renderFromPosition.renderer )
            go.transform.position = renderFromPosition.renderer.bounds.center;
 
        go.camera.RenderToCubemap( cubemap );
       
        currentMaterial.SetTexture("_Cube",cubemap);
            renderer.material = currentMaterial;
   
        //DestroyImmediate( go );
    }
 