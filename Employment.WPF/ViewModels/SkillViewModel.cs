﻿using Employment.WPF.Models;
using Employment.WPF.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Employment.WPF.ViewModels
{
    public class SkillViewModel : INotifyPropertyChanged
    {

        private Skill _skill;

        private bool _isSelected;
        public Skill Skill => _skill;

        public string Name => _skill.Name;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));

                    OnSelectedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler? OnSelectedChanged;
        public SkillViewModel(Skill skill)
        {
            _skill = skill ?? throw new ArgumentNullException(nameof(skill));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
