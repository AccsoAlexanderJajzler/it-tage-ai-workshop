#!/usr/bin/env bash

print_usage() {
    echo "Usage: $0 [html_file]"
}

convert_row_to_markdown() {
    local row=$1
    local row_type=$2 # 'header' or 'data'

    # Detect if the row is a header or data
    if [[ $row =~ "<th" ]]; then
        row_type="header"
    else
        row_type="data"
    fi

    row=$(echo "$row" | sed -e 's/<\/\?\(th\|td\)[^>]*>//g' -e 's/^\s*//g' -e 's/\s*$//g')
    local IFS=$'\n'
    local cells=($(grep -o '<td>.*</td>\|<th>.*</th>' <<< "$row"))
    local markdown_cells=()

    for cell in "${cells[@]}"; do
        # Strip HTML tags and escape pipes
        cell=$(echo "$cell" | sed -e 's/<[^>]*>//g' -e 's/|/\\|/g')
        markdown_cells+=("$cell")
    done

    if [ "$row_type" == "header" ]; then
        echo "| ${markdown_cells[*]} |"
        echo "|$(printf ' --- |' $(seq 1 ${#markdown_cells[@]}))"
    else
        echo "| ${markdown_cells[*]} |"
    fi
}

if [[ $# -ne 1 ]]; then
    echo "Error: Incorrect number of arguments."
    print_usage
    exit 1
fi

html_file="$1"

if [[ ! -f $html_file ]]; then
    echo "Error: File $html_file not found."
    exit 1
fi

rows=$(grep -oP '<tr>.+?</tr>' "$html_file")

# Convert each table row to Markdown
while IFS= read -r row; do
    convert_row_to_markdown "$row"
done <<< "$rows"
