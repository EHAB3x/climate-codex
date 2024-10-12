/* eslint-disable react/prop-types */
const InputField = ({ id, name, label, options, value, onChange }) => (
    <div className="input__filed flex flex-col flex-1">
      <label htmlFor={id}>{label}</label>
      <select id={id} name={name} value={value} onChange={onChange}>
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
    </div>
  );

  export default InputField;