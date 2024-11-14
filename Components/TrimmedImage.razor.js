export async function trimImage(
    url,
    imageElement,
) {
    try {
        const response = await fetch(url);
        const blob = await response.blob();

        const img = new Image();
        img.src = URL.createObjectURL(blob);
        img.crossOrigin = "Anonymous";

        img.onload = () => {
            const canvas = document.createElement("canvas");
            const context = canvas.getContext("2d");
            if (context) {
                canvas.width = img.width;
                canvas.height = img.height;
                context.clearRect(0, 0, canvas.width, canvas.height);
                context.drawImage(img, 0, 0);

                const imageData = context.getImageData(
                    0,
                    0,
                    canvas.width,
                    canvas.height
                );
                const {data} = imageData;

                let minX = canvas.width;
                let minY = canvas.height;
                let maxX = 0;
                let maxY = 0;

                for (let y = 0; y < canvas.height; y++) {
                    for (let x = 0; x < canvas.width; x++) {
                        const alpha = data[(y * canvas.width + x) * 4 + 3];

                        if (alpha > 0) {
                            minY = Math.min(minY, y);
                            maxY = Math.max(maxY, y);
                            minX = Math.min(minX, x);
                            maxX = Math.max(maxX, x);
                        }
                    }
                }

                const trimmedWidth = maxX - minX + 1;
                const trimmedHeight = maxY + 2;
                const trimmedCanvas = document.createElement("canvas");
                const trimmedContext = trimmedCanvas.getContext("2d");

                if (trimmedContext) {
                    trimmedCanvas.width = trimmedWidth;
                    trimmedCanvas.height = trimmedHeight;
                    trimmedContext.drawImage(
                        img,
                        minX, 
                        0,
                        trimmedWidth,
                        trimmedHeight,
                        0,
                        0,
                        trimmedWidth,
                        trimmedHeight
                    );
                    
                    imageElement.src =  trimmedCanvas.toDataURL();
                    imageElement.load();
                }
            }
        };
    } catch (error) {
        console.error("Error lading image:", error);
        toast("Couldnt load image", {
            description: "",
            action: {
                label: "Undo",
                onClick: () => console.log("Undo"),
            },
        });
    }
}