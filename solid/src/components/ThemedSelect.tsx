import { FiChevronDown } from "solid-icons/fi";
import { For, createSignal } from "solid-js";
import styles from "./ThemedSelect.module.scss";

interface ThemedSelectProps {
  options: string[];
  defaultValue?: string;
  onChange: (option: string) => void;
}

export default function ThemedSelect(props: ThemedSelectProps) {
  const [expanded, setExpanded] = createSignal(false);
  const [selected, setSelected] = createSignal(props.defaultValue ?? props.options[0]);

  // Close the select when the user clicks outside of it
  document.addEventListener("click", e => {
    if (e.target instanceof HTMLElement && !e.target.closest(`.${styles.select}`)) {
      setExpanded(false);
    }
  });

  const updateState = (option: string) => {
    if (option === selected()) return;
    setSelected(option);
    props.onChange(option);
  };

  return (
    <div class={styles.select} onClick={() => setExpanded(!expanded())}>
      <button class={`${styles.selected} ${expanded() ? styles.expanded : ""}`}>
        <span>{selected()}</span>
        <FiChevronDown style={expanded() ? { rotate: "-180deg" } : {}} />
      </button>
      <div class={`${styles.options} ${expanded() ? styles.expanded : ""}`}>
        <div class={styles.inner}>
          <For each={props.options}>
            {option => (
              <button
                disabled={!expanded()}
                class={selected() === option ? styles.active : ""}
                onClick={() => updateState(option)}
              >
                {option}
              </button>
            )}
          </For>
        </div>
      </div>
    </div>
  );
}
