import useQuery from "../hooks/useQuery";
import { ChevronLeft, ChevronRight, ChevronsLeft, ChevronsRight } from "lucide-react";
import useWindowResize from "../hooks/useWindowResize";
import { useState } from "react";

export default function PaginationButtons({ pageAmount, updatePageNumber }) {
  const query = useQuery();
  const currentPage = Number(query.get("page") ?? 1);
  const [buttons, setButtons] = useState(Math.min(5, pageAmount));

  useWindowResize(() => {
    if (window.innerWidth < 400) {
      setButtons(Math.min(3, pageAmount));
    } else {
      setButtons(Math.min(5, pageAmount));
    }
  }, true);

  if (pageAmount <= 1) {
    return null;
  }

  return (
    <div className="page-buttons">
      <div className="chevrons">
        {pageAmount > 3 && (
          <button disabled={currentPage <= 1} onClick={() => updatePageNumber(1)}>
            {<ChevronsLeft size={22} strokeWidth={1.5} absoluteStrokeWidth={true} />}
          </button>
        )}
        <button disabled={currentPage <= 1} onClick={() => updatePageNumber(currentPage - 1)}>
          {<ChevronLeft size={18} strokeWidth={1.5} absoluteStrokeWidth={true} />}
        </button>
      </div>

      {new Array(buttons).fill(null).map((_, i) => {
        let buttonNumber;

        if (currentPage < Math.ceil(buttons / 2)) {
          buttonNumber = i + 1;
        } else if (currentPage > pageAmount - Math.ceil(buttons / 2)) {
          buttonNumber = i + 1 + pageAmount - buttons;
        } else {
          buttonNumber = i + 1 + currentPage - Math.ceil(buttons / 2);
        }

        return (
          <button
            className="page-number-button"
            disabled={buttonNumber === currentPage}
            key={i}
            onClick={() => updatePageNumber(buttonNumber)}
          >
            {buttonNumber}
          </button>
        );
      })}

      <div className="chevrons">
        <button
          disabled={currentPage >= pageAmount}
          onClick={() => updatePageNumber(currentPage + 1)}
        >
          {<ChevronRight size={18} strokeWidth={1.5} absoluteStrokeWidth={true} />}
        </button>
        {pageAmount > 3 && (
          <button disabled={currentPage >= pageAmount} onClick={() => updatePageNumber(pageAmount)}>
            {<ChevronsRight size={22} strokeWidth={1.5} absoluteStrokeWidth={true} />}
          </button>
        )}
      </div>
    </div>
  );
}
