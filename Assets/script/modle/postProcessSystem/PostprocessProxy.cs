using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 此proxy的list仅仅为localProcess的list
class PostprocessProxy :Baseproxy<PostprocessModel>
{

    private static PostprocessProxy instance;

    public static PostprocessProxy instances() {
        if (instance == null) {
            instance = new PostprocessProxy();
        }
        return instance;

    }

    }

