import { ChevronDown } from "lucide-react";
import { useEffect, useState } from "react";

// ThemedDropdown component that displays a dropdown menu with options.
export default function ThemedDropdown({ options, value = "", onChange }) {
  const [expanded, setExpanded] = useState(false);

  // Close the dropdown when the user clicks outside of it
  useEffect(() => {
    const callback = (e) => {
      if (e.target.closest(".themed-dropdown") === null) setExpanded(false);
    };
    document.addEventListener("click", callback);
    return () => document.removeEventListener("click", callback);
  }, []);

  const updateState = (option) => {
    if (option === value) return;
    onChange(option);
  };

  return (
    <div className="themed-dropdown" onClick={() => setExpanded(!expanded)}>
      <button type="button" className="selected">
        <span>{value}</span> <ChevronDown style={expanded ? { rotate: "-180deg" } : {}} />
      </button>

      <div className={`dropdown ${expanded ? "expanded" : ""}`}>
        <div className="dropdown-inner">
          <div className="options">
            {options?.map((option) => (
              <button type="button" key={option} onClick={() => updateState(option)}>
                {option}
              </button>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}
