using UnityEngine;
using System.Collections;

public class activateObject : MonoBehaviour {
    public bool activated1 = false, activated2 = false, dualActivation = false, selected = false;
    public string activatedScript1, activatedScript2;
    public Sprite activeSprite;

    private SpriteRenderer spriteRend;
    private Sprite originalSprite;

    void Awake()
    {
        this.spriteRend = this.GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
        this.originalSprite = this.spriteRend.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        if (!selected)
        {
            colorUpdate();
        }

        else
        {
            this.spriteRend.color = new Color(255, 255, 255);
        }
	}

    public virtual void toggleSelection()
    {
        this.selected = !this.selected;
        if (this.selected)
        {
            this.spriteRend.sprite = this.activeSprite;
        }

        else
        {
            this.spriteRend.sprite = this.originalSprite;
        }
    }

    public void colorUpdate()
    {
        if (!dualActivation)
        {
            if (this.activated1)
            {
                this.spriteRend.color = new Color(0, 255, 0);
            }

            else
            {
                this.spriteRend.color = new Color(255, 255, 255);
            }
        }

        else
        {
            if (this.activated1 && this.activated2)
            {
                this.spriteRend.color = new Color(0, 255, 0);
            }

            else if (this.activated1 || this.activated2)
            {
                this.spriteRend.color = new Color(255, 220, 0);
            }

            else if (this.activatedScript1 != this.activatedScript2 || (!this.activated1 && !this.activated2))
            {
                this.spriteRend.color = new Color(255, 255, 255);
            }
        }
    }
}
