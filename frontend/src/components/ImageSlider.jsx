import { useEffect, useRef, useState } from "react";
import { apiDomain } from "../helpers/api-domain";
import { ChevronLeft, ChevronRight } from "lucide-react";

export default function ImageSlider({ imagePaths, altText }) {
  const [currentImage, setCurrentImage] = useState(0);
  const sliderRef = useRef(null);

  useEffect(() => {
    sliderRef.current.scroll({
      left: sliderRef.current.offsetWidth * currentImage,
      behavior: "smooth",
    });
  }, [currentImage]);

  return (
    <div className="image-slider">
      <div className="images-wrapper">
        <div className="images" ref={sliderRef}>
          {imagePaths.map((path, i) => (
            <img key={i} src={apiDomain.https + path} alt={altText} />
          ))}
        </div>
        <button
          className="left"
          disabled={currentImage == 0}
          onClick={() => setCurrentImage(currentImage - 1)}
        >
          <ChevronLeft />
        </button>
        <button
          className="right"
          disabled={currentImage == imagePaths.length - 1}
          onClick={() => setCurrentImage(currentImage + 1)}
        >
          <ChevronRight />
        </button>
      </div>
      <div className="bullets">
        {imagePaths.map((_, i) => (
          <button
            key={i}
            onClick={() => setCurrentImage(i)}
            className={currentImage == i ? "current" : ""}
          ></button>
        ))}
      </div>
    </div>
  );
}
