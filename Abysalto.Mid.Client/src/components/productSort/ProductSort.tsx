import {
  Box,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  Typography,
  type SelectChangeEvent,
} from "@mui/material";
import { useState } from "react";
import { PriceSortType } from "../../constants/PriceSortType";

interface ProductSortProps {
  onChange: (sortType: PriceSortType) => void;
}

export default function ProductSort({ onChange }: ProductSortProps) {
  const [sortOption, setSortOption] = useState<PriceSortType>(
    PriceSortType.DEFAULT
  );

  const handleChange = (event: SelectChangeEvent) => {
    const value = event.target.value as PriceSortType;
    setSortOption(value);
    onChange(value);
  };

  return (
    <Box
      sx={{
        minWidth: 120,
        maxWidth: 300,
        margin: "1rem",
      }}
    >
      <FormControl fullWidth>
        <InputLabel id="price-select-label">
          <Typography>Sort By Price</Typography>
        </InputLabel>
        <Select
          labelId="price-select-label"
          id="price-select"
          value={sortOption}
          label="Price"
          onChange={handleChange}
        >
          <MenuItem value={PriceSortType.DEFAULT}>
            <Typography>Default</Typography>
          </MenuItem>
          <MenuItem value={PriceSortType.LOWER_FIRST}>
            <Typography>Lower price first</Typography>
          </MenuItem>
          <MenuItem value={PriceSortType.HIGHER_FIRST}>
            <Typography>Higher price first</Typography>
          </MenuItem>
        </Select>
      </FormControl>
    </Box>
  );
}
